using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
public abstract class ICharacterVisitor
{
    public abstract void VisitorSoldier(IPlayer soldier);
    public abstract void VisitorEnemy(ISoldier enemy);
}

