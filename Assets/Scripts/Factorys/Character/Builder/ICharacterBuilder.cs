using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class ICharacterBuilder
{
    protected ICharacter mCharacter;
    protected System.Type mT;
    protected Vector3 mSpawnPosition;
    protected string mPrefabName;
    protected RoadType mRoadType;
    protected CampType mCampType;
    protected Transform[] mTowers;
    protected ICharacterAttr mAttr;
    protected Transform mStartParent;

    public ICharacterBuilder(Transform startParent, ICharacter character, System.Type t, Vector3 spawnPosition, RoadType roadType, 
        CampType campType, Transform[] towes)
    {
        mCharacter = character;
        mT = t;
        mSpawnPosition = spawnPosition;
        mCampType = campType;
        mRoadType = roadType;
        mTowers = towes;
        mPrefabName = character.prefabName;
        mStartParent = startParent;
    }

    public abstract void AddCharacterGO();
    public abstract void AddAttr();
    public abstract void SetTargets();
    public abstract void SetRoad();
    public abstract void SetType();
    public abstract void AddInCharacterSys();
    public abstract ICharacter GetResult();
}


