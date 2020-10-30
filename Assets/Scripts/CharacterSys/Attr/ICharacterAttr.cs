using System;
using System.Collections.Generic;
using System.Text;


public class ICharacterAttr
{

    protected string mName; // 名字
    protected string mIconSprite;   // 贴图
    protected int mMaxHP;   // 最大血量
    protected int mMaxMP;   // 最大蓝量
    protected float mCurrentHP;   // 当前血量
    protected float mCurrentMP;   // 当前蓝量
    protected int mLv;  // 士兵等级
    protected float mCritRate; // 0 - 1暴击率（只有玩家有）
    protected int mCD;    // 冷却缩减（只有玩家有）
    protected int mAttack;    // 攻击力
    protected int mPhysicalResistance;    // 物理抗性
    protected int mMagicResistance;    // 魔法抗性
    protected float mAttackSpeed;   // 攻击速度
    protected float mMoveSpeed; // 移动速度
    protected int mAttackRange; // 攻击范围

    protected IAttrStrategy mStrategy;  // 属性策略

    public ICharacterAttr(IAttrStrategy attrStrategy, string name, string iconSprite,  int maxHP, int maxMP, 
         int atk, int atkRange, int physicalRes, int magicRes, float atkSpeed, float moveSpeed, int cd = 0, int lv = 1, int critRate= 0)
    {
        mStrategy = attrStrategy;

        mName = name;
        mIconSprite = iconSprite;
        mMaxHP = maxHP;
        mMaxMP = maxMP;
        mCurrentHP = mMaxHP;
        mCurrentMP = mMaxMP;
        mLv = lv;
        mCritRate = critRate;
        mCD = cd;
        mAttack = atk;
        mPhysicalResistance = physicalRes;
        mMagicResistance = magicRes;
        mAttackSpeed = atkSpeed;
        mMoveSpeed = moveSpeed;
        mAttackRange = atkRange;
    }


    // 提供暴击伤害值
    public int critValue { get { return mStrategy.GetCritDmgValue(mCritRate)*mAttack; ; } }
    // 受到伤害 计算血量
    public void TakeDmg(int dmg)
    {
        if (dmg < 5) dmg = 5;
        mCurrentHP -= dmg;
        if (mCurrentHP < 0) mCurrentHP = 0; // 防止越界
    }
    public string Name { get { return mName; } }
    public string IconSprite { get { return mIconSprite; } }
    public string PrefabName { get; set; }
    public int MaxHP { get { return mMaxHP; } }
    public int MaxMP { get { return mMaxMP; } }
    public float CurrentHP { get { return mCurrentHP; } }
    public float CurrentMP { get { return mCurrentMP; } }
    public int Lv { get { return mLv; } }
    public float CritRate { get { return mCritRate; } }
    public int CD { get { return mCD; } }
    public int Attack { get { return mAttack; } }
    public int PhysicalResistance { get { return mPhysicalResistance; } }
    public int MagicResistance { get { return mMagicResistance; } }
    public float AttackSpeed { get { return mAttackSpeed; } }
    public float MoveSpeed { get { return mMoveSpeed; } }
    public float AttackRange { get { return mAttackRange; } }

}
    

