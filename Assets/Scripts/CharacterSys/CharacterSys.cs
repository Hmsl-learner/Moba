using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSys : IGameSys
{
    private List<ICharacter> mSoldiers = new List<ICharacter>();

    private List<ICharacter> mPlayers = new List<ICharacter>();


    public void AddSoldier(ISoldier soldier)
    {
        mSoldiers.Add(soldier);
    }
    public void RemoveSoldier(ISoldier soldier)
    {
        mSoldiers.Remove(soldier);
    }
    public void AddPlayer(IPlayer player)
    {
        mPlayers.Add(player);
    }
    public void RemovePlayer(IPlayer player)
    {
        mPlayers.Remove(player);
    }
    

    public override void Update()
    {
        UpdateSoldier();
        UpdatePlayer();
        RemoveCharacter(mSoldiers);
        RemoveCharacter(mPlayers);
    }
    /// <summary>
    /// 更新小兵和状态机
    /// </summary>
    private void UpdateSoldier()
    {
        //Debug.Log(mEnemys.Count);
        foreach (ISoldier e in mSoldiers)
        {
            e.Update();
            e.UpdateFSMAI();
        }
    }
    /// <summary>
    /// 更新角色
    /// </summary>
    private void UpdatePlayer()
    {
        foreach (IPlayer s in mPlayers)
        {
            s.Update();
        }
    }
    private void RemoveCharacter(List<ICharacter> characters)
    {
        
        for (int i=0;i<characters.Count;i++)
        {
            if (characters[i].isKilled)
            {
                characters[i].Release();
                characters.Remove(characters[i]);
            }
        }
        
    }
    /// <summary>
    /// 观察者
    /// </summary>
    /// <param name="visitor"></param>
    public void RunVisitor(ICharacterVisitor visitor)
    {
        foreach(ICharacter character in mPlayers)
        {
            character.RunVisitor(visitor);
        }
        foreach (ICharacter character in mSoldiers)
        {
            character.RunVisitor(visitor);
        }
    }
}
