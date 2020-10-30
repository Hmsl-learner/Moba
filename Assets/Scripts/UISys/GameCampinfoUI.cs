using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class GameCampinfoUI : IBaseUI
{
    private Image mCampIcon;    // camp图标
    private Text mCampName;     // camp名字

    private ICamp mCamp;    //  点击的兵营




    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "CampInfoUI");

        mCampIcon = UITool.FindChild<Image>(mRootUI,"CampIcon");    
        mCampName = UITool.FindChild<Text>(mRootUI, "CampName");    
       

        Hide();
    }

    public override void Update()
    {
        base.Update();
        if (mCamp != null)
        {
            ShowTrainingInfo();
        }
    }

    public void ShowCampInfo(ICamp camp)
    {
        mFacade.HideSoldier();
        Show();
        mCamp = camp;
        mCampIcon.sprite = FactoryManager.assetFactory.LoadSprite(camp.iconSprite);
        mCampName.text = camp.name;
        //mCampLevel.text = camp.lv.ToString();


    }
    // UI更新显示属性
    private void ShowTrainingInfo()
    {
       
    }
   

    
    public void HideCamp()
    {
        Hide();
    }
    
}
  

