﻿using UnityEngine;
using System.Collections;

//Assets-->Create-->Abilities-->New ability
[CreateAssetMenu(menuName = "Ability/New Targeted ability")]
public class Targeted : Ability
{
    private TargetedBehavior targeted;
    /// <summary>
    /// Give the information from the scriptable object to the monobehavior
    /// handlers. 
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(GameObject obj)
    {
        targeted = obj.GetComponent<TargetedBehavior>();
        targeted.abilityObject = abilityObject;
        targeted.maxRange = maxRange;
    }

    /// <summary>
    /// Cast ability using monobehavior handlers. Used to cast generic
    /// abilities. More complicated things may not be able to be done here.
    /// </summary>
    public override void cast()
    {
        targeted.cast();
    }
}
