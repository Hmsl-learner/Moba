using System;
using System.Collections.Generic;
using UnityEngine;

class SoldierOnCilck : MonoBehaviour
{
    private ICharacter mSoldier;
    public ICharacter soldier { set { mSoldier = value; } }
    private void OnMouseUpAsButton()
    {
        GameManager.Instance.ShowSoldierInfo(mSoldier);
    }
}

