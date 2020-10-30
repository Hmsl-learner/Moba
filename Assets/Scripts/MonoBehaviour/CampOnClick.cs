﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CampOnClick:MonoBehaviour
{
    private ICamp mCamp;
    public ICamp camp { set { mCamp = value; } }
    private void OnMouseUpAsButton()
    {
        GameManager.Instance.ShowCampInfo(mCamp);
    }
}

