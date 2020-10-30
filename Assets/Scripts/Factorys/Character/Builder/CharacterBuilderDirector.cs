using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CharacterBuilderDirector
{
    public ICharacter Construct(ICharacterBuilder builder)
    {
        builder.AddCharacterGO();
        builder.AddAttr();
        builder.SetRoad();
        builder.SetType();
        builder.SetTargets();
        builder.AddInCharacterSys();
        return builder.GetResult();
    }
}

