using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;


public abstract class ICharacter
{
    protected GameManager mFacade = GameManager.Instance;

    protected ICharacterAttr mAttr;  // 角色属性
    protected GameObject mGameObject;   // 角色物体
    protected NavMeshAgent mNavAgent;   // 导航组件
    protected AudioSource mAudio;   // 声音组件
    protected Animation mAnim;  // 动画组件
    protected string mPrefabName;   //预制体名
    protected RoadType mRoadType;   // 路线
    protected CampType mCampType;   // 阵营
    protected Transform[] mTargets;  // 目标 
    protected bool mIsKilled = false;

    protected SoldierMono mMono;

    // 位置索引
    public Vector3 position
    {
        get {
            if (mGameObject == null)
            {
                Debug.LogError("mGameObject为空"); return Vector3.zero;
            }
            return mGameObject.transform.position;
        }
    }
    // 可销毁属性索引
    public bool isKilled { get { return mIsKilled; } }
    // 攻击范围索引
    public float atkRange { get { return mAttr.AttackRange; }}
    // 属性索引
    public ICharacterAttr attr { set { mAttr = value; }  get { return mAttr; }  }
    // 物体索引
    public GameObject gameObject
    {
        set
        {
            mGameObject = value;    // 绑定游戏物体

            mNavAgent = mGameObject.GetComponent<NavMeshAgent>();   // 获取导航组件
            mAudio = mGameObject.GetComponent<AudioSource>();   // 获取声音组件
            mAnim = mGameObject.GetComponentInChildren<Animation>();    // 获取动画组件
        }
        get { return mGameObject; }
        
    }
    public SoldierMono mono { get { return mMono; } set { mMono = value; } }
    public int atk { get { return mAttr.Attack; } }
    // 预制体名
    public string prefabName { get { return mPrefabName; } }
    public RoadType roadType { get { return mRoadType; } set { mRoadType = value; } }
    public CampType campType { get; set; }
    public Transform[] targets { get { return mTargets; } set { mTargets = value; } }

    public void Update()
    {
        
    }

    public virtual void UpdateFSMAI() { }
    public virtual void RunVisitor(ICharacterVisitor visitor) { }
    public void Attack(Transform target)
    {
        mNavAgent.isStopped = true;
        mGameObject.transform.LookAt(target.position);  // 转向
        PlayAnim("Attack1"); // 攻击动画
         // TODO攻击效果
        //target.UnderAttack(atk+mAttr.critValue);    // 目标受到伤害（武器伤害+暴击加成）
    }
    public virtual void UnderAttack(int dmg)
    {
        mAttr.TakeDmg(dmg); // 受到攻击
    }
    public void Stand()
    {
        mNavAgent.isStopped = true;
        PlayAnim("stand");
    }
    public virtual void Killed()
    {
        mIsKilled = true;
        mNavAgent.isStopped =true;
    }
    public void Release()
    {
        GameObject.Destroy(mGameObject);
    }
    public void PlayAnim(string animName)
    {
        mAnim.CrossFade(animName);  // 播放动画
    }
    // 移动方法
    public void MoveTo(Vector3 targetPosition)
    {
        mNavAgent.areaMask = (int)mRoadType;
        mNavAgent.enabled = true;
        mNavAgent.SetDestination(targetPosition);   // 设置目标位置
        mNavAgent.isStopped = false;
        PlayAnim("Run");   // 播放动画
    }

    // 播放音效
    protected void PlaySound(string soundName)
    {
        AudioClip audioClip = FactoryManager.assetFactory.LoadAudioClip(soundName); // 获取音效
        //Debug.Log(audioClip);
        mAudio.clip = audioClip;    // 绑定
        mAudio.Play();  //播放
    }
    // 播放特效
    protected void PlayEffect(string effectName)
    {
        // 加载特效 
        GameObject effecGO = FactoryManager.assetFactory.LoadEffect(effectName, mGameObject.transform);    // 获取特效
        //Debug.Log(effecGO);
        effecGO.transform.position = position;  // 播放位置
        effecGO.AddComponent<DestroyForTime>(); // 添加销毁组件
        effecGO.GetComponentInChildren<ParticleSystem>().Play();
    }

    
}
    
