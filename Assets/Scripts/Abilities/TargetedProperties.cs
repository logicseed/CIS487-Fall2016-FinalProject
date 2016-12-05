using UnityEngine;
using System.Collections;

/// <summary>
/// Properties for targeted ability behavior
/// Create a new unity ability asset: Assets --> Create --> Ability --> New Targeted ability
/// </summary>
[CreateAssetMenu(menuName = "Ability/New Targeted ability")]
public class TargetedProperties : Ability
{
    TargetedBehavior targeted;
    public GameObject abilityObject;
    public float maxCastRange;

    /// <summary>
    /// Give the information from the scriptable object to the monobehavior handler. 
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(GameObject obj)
    {
        targeted = obj.GetComponent<TargetedBehavior>();
        targeted.abilityObject = abilityObject;
        targeted.maxRange = maxCastRange;
    }

    /// <summary>
    /// Cast ability using monobehavior handler. 
    /// </summary>
    public override void cast()
    {
        targeted.cast();
    }
}

