using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPlayer : ICharacter
{
    protected string mEffectName;   // 特效名
    protected string mSoundName;    // 音效名
    
    public IPlayer():base()
    {

    }
    

    public override void UnderAttack(int dmg)
    {
        if (mIsKilled) return;

        base.UnderAttack(dmg);

        if (mAttr.CurrentHP <= 0)
        {
            // 死亡
            PlaySound(mSoundName);
            //Debug.Log(mEffectName);
            PlayEffect(mEffectName);
            //Debug.Log("kill");
            Killed();
        }
    }

    public override void Killed()
    {
        base.Killed();
        mFacade.NotifySubject(GameEventType.SoldierKilled);
    }

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitorSoldier(this);
    }
}
