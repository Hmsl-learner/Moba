﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class StartState: ISceneState
{
    public StartState(SceneStateController controller):base("01-Begin",controller)
    { }

    private Image mLogo;
    private float mSmoothingSpeed = 1;
    private float mWaitTime =2;
    public override void StateStart()
    {
        mLogo = GameObject.Find("Logo").GetComponent<Image>();
        mLogo.color = Color.black;
    }

    public override void StateUpdate()
    {
        mLogo.color = Color.Lerp(mLogo.color, Color.white, mSmoothingSpeed * Time.deltaTime);
        mWaitTime -= Time.deltaTime;
        if (mWaitTime <= 0)
        {
            mController.SetState(new MainMenuState(mController));
        }
    }
}
    

