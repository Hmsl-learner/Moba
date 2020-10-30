using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IGameSys
{
    protected GameManager mManager;
    protected GameObject mMapParentGO;
    public virtual void Init() {
        mManager = GameManager.Instance;
        mMapParentGO = GameObject.Find("5v5");
    }
    public virtual void Update(){ }
    public virtual void Release() { }
}

