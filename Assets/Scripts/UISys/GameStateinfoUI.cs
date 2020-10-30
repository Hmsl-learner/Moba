using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameStateinfoUI : IBaseUI
{
    private List<GameObject> mHearts;
    private Text mSoldierCount;
    private Text mEnemyCount;
    private Text mCurrentStage;
    private Button mPauseBtn;
    private GameObject mGameOverUI;
    private Button mBackMenueBtn; 
    private Text mTipMessage;
    private Slider mEnergySlider;
    private Text mEnergyText;

    private float mTipTimer  = 0;
    private float mTipTime = 2;

    private AliveCountVisitor mAliveCountVisitor = new AliveCountVisitor();


    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GameStateUI");

        GameObject heart1 = UnityTool.FindChild(mRootUI, "Heart1");
        GameObject heart2 = UnityTool.FindChild(mRootUI, "Heart2");
        GameObject heart3 = UnityTool.FindChild(mRootUI, "Heart3");
        mHearts = new List<GameObject>
        {
            heart1,
            heart2,
            heart3
        };
        mSoldierCount = UITool.FindChild<Text>(mRootUI, "SoldierCount");
        mEnemyCount = UITool.FindChild<Text>(mRootUI, "EnemyCount");
        mCurrentStage = UITool.FindChild<Text>(mRootUI, "StageCount");
        mPauseBtn = UITool.FindChild<Button>(mRootUI, "PauseBtn");
        mGameOverUI = UnityTool.FindChild(mRootUI, "GameOver");
        mBackMenueBtn = UITool.FindChild<Button>(mRootUI, "BackMenueBtn");
        mTipMessage = UITool.FindChild<Text>(mRootUI, "TipMessage");
        mEnergySlider = UITool.FindChild<Slider>(mRootUI, "EnergySlider");
        mEnergyText = UITool.FindChild<Text>(mRootUI, "EnergyText");

        mTipMessage.text = "";
        mGameOverUI.SetActive(false);

        mBackMenueBtn.onClick.AddListener(OnBackClick);
        mPauseBtn.onClick.AddListener(OnPauseClick);

    }
    public override void Update()
    {
        base.Update();
       
        if(mTipTimer < mTipTime)
        {
            mTipTimer += Time.deltaTime;
            if (mTipTimer >= mTipTime)
            {
                mTipTimer = 0;
                mTipMessage.text = "";
            }
        }
        UpdateAliveCount();
        if (mHearts.Count == 0)
        {
            Time.timeScale = 0;
            mGameOverUI.SetActive(true);
        }
    }
    public void ShowTip(string msg)
    {
        mTipMessage.text = msg;
    } 
    public void UpdateEnergySlider(float nowEnergy, int maxEnergy)
    {
        mEnergySlider.value = nowEnergy / maxEnergy;
        mEnergyText.text = "(" + nowEnergy + "/" + maxEnergy + ")";
    }
    public void UpdateAliveCount()
    {
        mAliveCountVisitor.Reset();
        mFacade.RunVisitor(mAliveCountVisitor);
        mSoldierCount.text = mAliveCountVisitor.mSoldierAliveCount.ToString();
        mEnemyCount.text = mAliveCountVisitor.mEnemyAliveCount.ToString();
    }
    public void UpdateStageCount(int stageCount)
    {
        mCurrentStage.text = stageCount.ToString();
    }
    private void OnPauseClick()
    {
        Time.timeScale = 0;
        mFacade.ShowPauseUI();
    }
    public void TargetAtked()
    {
        //foreach (GameObject g in mHearts) Debug.Log(g.name);
        mHearts[mHearts.Count-1].SetActive(false);
        mHearts.RemoveAt(mHearts.Count - 1);
    }
    private void OnBackClick()
    {
        mFacade.IsGameOver = true;
    }
    public string currentStageCount { get { return mCurrentStage.text; } }
}
   

