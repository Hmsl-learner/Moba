using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;





/// <summary>
/// 状态接口
/// </summary>
public abstract class ISoldierState
{
    // 声明存放【转换条件】-【状态ID】的字典
    protected Dictionary<SoldierTransition, SoldierStateID> mMap = new Dictionary<SoldierTransition, SoldierStateID>();
    // 声明状态ID
    protected SoldierStateID mStateID;
    // 声明角色接口
    protected ICharacter mCharacter;
    // 声明FSM
    protected SoldierFSMSys mFSM;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="fsm"></param>
    /// <param name="character"></param>
    public ISoldierState(SoldierFSMSys fsm, ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }

    // 提供获取状态ID的方法
    public SoldierStateID stateID { get { return mStateID; } }

    // 添加状态转换关系
    public void AddTransition(SoldierTransition trans, SoldierStateID id)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("IEnemyState Error: trans 不能为空"); return;
        }
        if (id == SoldierStateID.NullState)
        {
            Debug.LogError("IEnemyState Error: id 不能为空"); return;
        }
        if (mMap.ContainsKey(trans))
        {
            Debug.LogError("IEnemyState Error: [" + trans + "]已经存在"); return;
        }
        mMap.Add(trans, id);
    }
    // 删除状态转换关系
    public void DeleteTransition(SoldierTransition trans)
    {
        if (mMap.ContainsKey(trans) == false)
        {
            Debug.LogError("IEnemyState Error:[" + trans + "]不存在");
        }
        mMap.Remove(trans);
    }
    // 获取转换条件对应的状态ID
    public SoldierStateID GetOutPutState(SoldierTransition trans)
    {
        if (mMap.ContainsKey(trans) == false)
        {
            Debug.LogError("找不到与[" + trans + "]匹配的状态");
            return SoldierStateID.NullState;
        }
        else
        {
            return mMap[trans];
        }
    }

    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }
    public abstract void Reason(List<ICharacter> targets, Transform finalTarget);  // 状态转变
    public abstract void Act(List<ICharacter> targets, Transform finalTarget); // 行为
}


