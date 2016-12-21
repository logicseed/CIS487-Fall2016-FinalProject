using UnityEngine;
using System.Collections;

/// <summary>
/// Properties for a blast non targeted ability behavior
/// Create a new unity ability asset: Assets --> Create --> Ability --> New Non targeted ability
/// </summary>
[CreateAssetMenu(menuName = "Ability/New Non targeted ability")]
public class NonTargetedProperties : Ability
{
    NonTargetedBehavior nonTargeted;
    public GameObject abilityObject;
    public float maxCastRange;

    /// <summary>
    /// Give the information from the scriptable object to the monobehavior handler. 
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(GameObject obj)
    {
        nonTargeted = obj.GetComponent<NonTargetedBehavior>();
        nonTargeted.abilityObject = abilityObject;
        nonTargeted.maxRange = maxCastRange;
    }

    /// <summary>
    /// Cast ability using monobehavior handler. 
    /// </summary>
    public override void cast()
    {
        nonTargeted.Cmdcast();
    }
}
