using UnityEngine;
using System.Collections;
using System;

public class TestAbility : AbstractAbility
{
    //Plan for ability inheritance
    TestAbility()
    {
        description = "Skill shot";
        name = "Test";
        effect = (int)EffectList.Damage;
    }

    public override void cast()
    {
        throw new NotImplementedException();
    }

    public override void destroyCast()
    {
        throw new NotImplementedException();
    }
}