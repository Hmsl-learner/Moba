using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
public class AliveCountVisitor : ICharacterVisitor
{
    public int mEnemyAliveCount { get; private set; }
    public int mSoldierAliveCount { get; private set; }
    public override void VisitorEnemy(ISoldier enemy)
    {
        if(!enemy.isKilled) mEnemyAliveCount++;
    }

    public override void VisitorSoldier(IPlayer soldier)
    {
        if (!soldier.isKilled) mSoldierAliveCount++;
    }
    public void Reset()
    {
        mEnemyAliveCount = 0;
        mSoldierAliveCount = 0;
    }
}

