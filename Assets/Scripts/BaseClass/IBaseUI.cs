using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IBaseUI 
{
    protected GameManager mFacade;

    public GameObject mRootUI;

    public virtual void Init() {
        mFacade = GameManager.Instance;
    }
    public virtual void Update() { }
    public virtual void Release() { }

    protected void Show()
    {
        mRootUI.SetActive(true);
    }
    protected void Hide()
    {
        mRootUI.SetActive(false);
        //Debug.Log("Hide" +mRootUI.name);
    }
}
