using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierChaseState : ISoldierState
{
    public SoldierChaseState(SoldierFSMSys fsm, ICharacter c) : base(fsm, c) { mStateID = SoldierStateID.Chase; }

    private Vector3 mTargetPosition;
    public override void DoBeforeEntering()
    {
    }
    public override void Act(List<ICharacter> targets, Transform finalTarget)
    {
        mTargetPosition = mCharacter.targets[0].position;
        if(targets != null && targets.Count > 0)
        {
            //Debug.Log("chasesoldier");
            mCharacter.MoveTo(targets[0].position);
        }
        else
        {
            mCharacter.MoveTo(mTargetPosition);
        }
       
    }
    /// <summary>
    /// 转换条件，攻击范围内有小兵就攻击小兵，如果没有小兵就判断目标防御塔是否在攻击范围内
    /// </summary>
    /// <param name="targets"></param>
    public override void Reason(List<ICharacter> targets, Transform finalTarget)
    {
        if(targets !=null && targets.Count > 0)
        {
            float distance = Vector3.Distance(mCharacter.position, targets[0].position);
            if(distance < mCharacter.atkRange)
            {
                mFSM.PerformTransition(SoldierTransition.CanAttack);
            }
            else if (Vector3.Distance(mCharacter.targets[0].position, mCharacter.position) < mCharacter.atkRange)
            {
                mFSM.PerformTransition(SoldierTransition.CanAttack);
            }
        }
    }

    
}

