using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SoldierAttackState:ISoldierState
{
    public SoldierAttackState(SoldierFSMSys fsm, ICharacter c) : base(fsm, c) 
    {
        mStateID = SoldierStateID.Attack;
        mAttackTimer = mAttackTime;
    }

    private float mAttackTimer;  
    private float mAttackTime = 2;  // 攻击间隔
    /// <summary>
    /// 如果有目标可以攻击就开始攻击，先攻击敌方小兵 再攻击防御塔
    /// </summary>
    /// <param name="targets"></param>
    public override void Act(List<ICharacter> targets, Transform finalTarget)
    {
        if (targets == null || targets.Count == 0)
        {
            if (finalTarget==null) return;
            else mAttackTime += Time.deltaTime;
            if (mAttackTimer >= mAttackTime)
            {
                mCharacter.Attack(finalTarget);
                mAttackTimer = 0;
            }
        }
        else
        {
            mAttackTimer += Time.deltaTime;
            if (mAttackTimer >= mAttackTime)
            {
                mCharacter.Attack(targets[0].gameObject.transform);
                mAttackTimer = 0;
            }
        }
    }
    /// <summary>
    /// 如果小兵跑出攻击范围了，就去追击； 如果在攻击的防御塔毁了或者小兵杀完了，就去追下一个防御塔
    /// </summary>
    /// <param name="targets"></param>
    public override void Reason(List<ICharacter> targets, Transform finalTarget)
    {
        if(targets == null || targets.Count == 0)
        {
            if (Vector3.Distance(mCharacter.position, finalTarget.position) > mCharacter.atkRange)
            {
                mFSM.PerformTransition(SoldierTransition.LostSoldier);
            }
        }
        else
        {
            float distance = Vector3.Distance(mCharacter.position, targets[0].position);
            if(distance > mCharacter.atkRange)
            {
                mFSM.PerformTransition(SoldierTransition.LostSoldier);
            }
        }
    }
}

