using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 状态机
/// </summary>
public class SoldierFSMSys
{
    // 声明状态接口序列
    private List<ISoldierState> mState = new List<ISoldierState>();
    // 声明当前状态
    private ISoldierState mCurrentState;
    // 提供获取当前状态的方法
    public ISoldierState currentState { get { return mCurrentState; } }

    // 向状态序列中添加状态
    public void AddState(params ISoldierState[] states)
    {
        foreach (ISoldierState s in states)
        {
            AddState(s);
        }
    }
    public void AddState(ISoldierState state)
    {
        if (state == null)
        {
            Debug.LogError("添加对象[" + state + "]为空");
        }
        if (mState.Count == 0)
        {
            mState.Add(state);
            mCurrentState = state;
            mCurrentState.DoBeforeEntering();
            return;
        }
        foreach (ISoldierState s in mState)
        {
            if (s.stateID == state.stateID)
            {
                Debug.LogError("添加对象[" + state + "]已经存在"); return;
            }
        }
        mState.Add(state);
    }
    // 从状态序列中删除状态
    public void DeleteState(SoldierStateID id)
    {
        if (id == SoldierStateID.NullState)
        {
            Debug.LogError("删除对象[" + id + "]为空"); return;
        }
        foreach (ISoldierState s in mState)
        {
            if (s.stateID == id)
            {
                mState.Remove(s); return;
            }
        }
        Debug.LogError("删除对象[" + id + "]不存在");
    }
    // 执行状态转换
    public void PerformTransition(SoldierTransition trans)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("要执行的条件为空"); return;
        }
        SoldierStateID nextID = mCurrentState.GetOutPutState(trans);
        if (nextID == SoldierStateID.NullState)
        {
            Debug.LogError("转换条件[" + trans + "]没有对应的状态");
        }
        foreach (ISoldierState s in mState)
        {
            if (s.stateID == nextID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = s;
                mCurrentState.DoBeforeEntering();
                return;
            }
        }
    }

}


