using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ISoldier : ICharacter
{
    protected SoldierFSMSys mFSMSys;  // 状态机
    //protected string mEffectName;   // 特效名
    protected List<ICharacter> mFSMAITargets;
    public ISoldier()
    {
        MakeFSM();
    } 

    public override void UpdateFSMAI()
    {
        mFSMAITargets = mMono.targets;
        //TODO 更新状态机目标
        if (mIsKilled) return;
        mFSMSys.currentState.Reason(mFSMAITargets ,targets[0]);
        //Debug.Log("act");
        mFSMSys.currentState.Act(mFSMAITargets, targets[0]);
    }

    private void MakeFSM()
    {
        mFSMSys = new SoldierFSMSys();

        SoldierChaseState chaseState = new SoldierChaseState(mFSMSys, this);
        chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);

        SoldierAttackState attackState = new SoldierAttackState(mFSMSys, this);
        attackState.AddTransition(SoldierTransition.LostSoldier, SoldierStateID.Chase);

        mFSMSys.AddState(chaseState, attackState);
    }
    public override void UnderAttack(int dmg)
    {
        if (mIsKilled) return;

        base.UnderAttack(dmg);

        if (mAttr.CurrentHP <= 0)
        {
            Killed();
            // TODO死亡效果
            //PlayEffect(mEffectName);
        }
    }
    public override void Killed()
    {
        base.Killed();
        mFacade.NotifySubject(GameEventType.EnemyKilled);
    }
    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitorEnemy(this);
    }
    
}
