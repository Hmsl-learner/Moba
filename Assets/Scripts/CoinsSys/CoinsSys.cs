using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSys : IGameSys
{
    private const int MAX_Energy = 100;

    private float mNowEnergy;
    private float mRecoverSpeed = 2f;

    public override void Init()
    {
        base.Init();
        mNowEnergy = 20;
    }
    public override void Update()
    {
        base.Update();

        if (mNowEnergy == MAX_Energy) return;
        mNowEnergy += mRecoverSpeed * Time.deltaTime;
        mNowEnergy = Mathf.Min(mNowEnergy, MAX_Energy);
    }
    public bool TakeEnergy(int val)
    {
        if (mNowEnergy >= val)
        {
            mNowEnergy -= val;
            return true;
        }
        return false;
    }
    public void RecycleEnergy(int val)
    {
        mNowEnergy += val;
        mNowEnergy = Mathf.Min(mNowEnergy, MAX_Energy);
    }

    public void RewardEnergy()
    {
        mNowEnergy += 5;
    }
}
