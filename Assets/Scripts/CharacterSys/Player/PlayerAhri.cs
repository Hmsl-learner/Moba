using System;
using System.Collections.Generic;
using System.Text;


public class PlayerAhri : IPlayer
{
    public PlayerAhri():base()
    {
        mEffectName = "CaptainDeadEffect";
        mSoundName = "CaptainDeath";
    }
}

