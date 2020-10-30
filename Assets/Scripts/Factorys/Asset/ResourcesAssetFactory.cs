using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ResourcesAssetFactory : IAssetFactory
{
    private const string PlayerPath = "Charactors/Player/";
    private const string SoldierPath = "Charactors/Soldier/";
    private const string WeaponPath = "Weapons/";
    private const string EffectPath = "Effects/";
    private const string AudioPath = "Audios/";
    private const string SpritePath = "Sprites/";

    public AudioClip LoadAudioClip(string name)
    {
        return Resources.Load(AudioPath + name, typeof(AudioClip)) as AudioClip;
    }

    public GameObject LoadEffect(string name, Transform parent)
    {
        return InstantiateGO(EffectPath + name, parent);
    }

    public GameObject LoadSoldier(string name, Transform parent)
    {
        return InstantiateGO(SoldierPath + name, parent);
    }

    public GameObject LoadPlayer(string name, Transform parent)
    {
        return InstantiateGO(PlayerPath + name, parent);
    }

    public Sprite LoadSprite(string name)
    {
        return Resources.Load(SpritePath + name, typeof(Sprite)) as Sprite;
    }


    // 实例化加载
    private GameObject InstantiateGO(string path, Transform parent)
    {
        UnityEngine.Object o = Resources.Load(path);
        if(o == null)
        {
            Debug.LogError("无法加载资源，路径：" + path);return null;
        }
        return UnityEngine.Object.Instantiate(o, parent.position, Quaternion.identity, parent) as GameObject;
    }
}

