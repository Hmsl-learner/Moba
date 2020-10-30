using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public interface IAssetFactory
{
    GameObject LoadPlayer(string name, Transform parent);
    GameObject LoadSoldier(string name, Transform parent);
    GameObject LoadEffect(string name, Transform parent);
    AudioClip LoadAudioClip(string name);
    Sprite LoadSprite(string name);
}

