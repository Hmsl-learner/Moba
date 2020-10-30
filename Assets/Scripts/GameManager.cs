using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

/// <summary>
/// 外观类：为一组接口提供统一的入口供外部使用，降低耦合
/// 中介类：作为子系统之间交互的中介，降低耦合
/// </summary>
public class GameManager
{
    private static GameManager _instance = new GameManager();

    public bool IsGameOver{ get; set; } // 游戏结束
    public static GameManager Instance { get{ return _instance; } }
    private GameManager() { }

    // 创建子系统的对象
    private CampSys mCampSys;
    private CharacterSys mCharacterSys;
    private CoinsSys mCoinsSys;
    private GameEventSys mGameEventSys;

    private GameCampinfoUI mCampinfoUI;
    private GamePauseUI mPauseUI;
    private GameSoldierinfoUI mSoldierinfoUI;

    public void Init()
    {
        mCampSys = new CampSys();
        mCharacterSys = new CharacterSys();
        mCoinsSys = new CoinsSys();
        mGameEventSys = new GameEventSys();

        mCampinfoUI = new GameCampinfoUI();
        mPauseUI = new GamePauseUI();
        mSoldierinfoUI = new GameSoldierinfoUI();

        mCampSys.Init();
        mCharacterSys.Init();
        //mCoinsSys.Init();
        //mGameEventSys.Init();

        //mCampinfoUI.Init();
        //mPauseUI.Init();
        //mSoldierinfoUI.Init();

    }
    public void Update()
    {
        mCampSys.Update();
        mCharacterSys.Update();
        //mCoinsSys.Update();
        //mGameEventSys.Update();

        //mCampinfoUI.Update();
        //mPauseUI.Update();
        //mSoldierinfoUI.Update();
    }
    public void Release()
    {

        mCampSys.Release();
        mCharacterSys.Release();
        mCoinsSys.Release();
        mGameEventSys.Release();

        mCampinfoUI.Release();
        mPauseUI.Release();
        mSoldierinfoUI.Release();
    }

    // 设置目标
    public Vector3 GetEnemyTargetPosition()
    {
        return Vector3.zero;
    }

    public void ShowCampInfo(ICamp camp)
    {
        mCampinfoUI.ShowCampInfo(camp);
    }

    // 将生产出的角色交给CharacterSys管理
    public void AddSoldier(ISoldier soldier)
    {
        mCharacterSys.AddSoldier(soldier);
    }
    public void AddPlayer(IPlayer player)
    {
        mCharacterSys.AddPlayer(player);
    }
    public void RemoveSoldier(ISoldier soldier)
    {
        mCharacterSys.RemoveSoldier(soldier);
    }
    public void RemovePlayer(IPlayer player)
    {
        mCharacterSys.RemovePlayer(player);
    }

    public bool TakeEnergy(int val)
    {
        return mCoinsSys.TakeEnergy(val);
    }
    public void RecycleEnergy(int val)
    {
        mCoinsSys.RecycleEnergy(val);
    }
    public void RewardEnergy()
    {
        mCoinsSys.RewardEnergy();
    }
    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mGameEventSys.RegisterObserver(eventType, observer);

    }
    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mGameEventSys.RemoveObserver(eventType, observer);

    }
    public void NotifySubject(GameEventType eventType)
    {
        mGameEventSys.NotifySubject(eventType);
    }
    public void RunVisitor(ICharacterVisitor visitor)
    {
        mCharacterSys.RunVisitor(visitor);
    }
    public void ShowPauseUI()
    {
        mPauseUI.ShowPauseUI();
    }
    public void ShowSoldierInfo(ICharacter soldier)
    {
        mSoldierinfoUI.ShowSoldierInfo(soldier);
    }
    public void HideCamp()
    {
        mCampinfoUI.HideCamp();
    }
    public void HideSoldier()
    {
        mSoldierinfoUI.HideSoldier();
    }
    
} 
   
