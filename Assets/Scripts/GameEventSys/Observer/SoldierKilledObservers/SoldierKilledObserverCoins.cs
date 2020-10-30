using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
public class SoldierKilledObserverCoins : IGameEventObserver
{
    private CoinsSys mCoinSys;
    public SoldierKilledObserverCoins(CoinsSys coinsSys)
    {
        mCoinSys = coinsSys;
    }
    public override void SetSubject(IGameEventSubject subject)
    {
        return;
    }

    public override void Update()
    {
        GameManager.Instance.RewardEnergy();
    }
}

