using System;
using System.Collections.Generic;
using System.Text;


public class PlayerAttr : ICharacterAttr
{
    public PlayerAttr(IAttrStrategy attrStrategy, string name, string iconSprite, int maxHP, int maxMP, 
        int atk, int atkRange, int physicalRes, int magicRes, float atkSpeed, float moveSpeed, int cd, int lv, int critRate = 0) :
        base(attrStrategy, name, iconSprite, maxHP, maxMP,  atk, atkRange, physicalRes, magicRes, atkSpeed, moveSpeed, cd, lv, critRate)
    {

    }
}

