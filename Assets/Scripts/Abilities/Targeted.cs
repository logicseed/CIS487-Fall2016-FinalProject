using UnityEngine;
using System.Collections;

//Assets-->Create-->Abilities-->New ability
[CreateAssetMenu(menuName = "Abilities/New Targeted")]
public class PointClick : AbstractAbility
{
    private TargetedTrigger targeted;
    /// <summary>
    /// Give the information from the scriptable object to the monobehavior
    /// handlers. 
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(GameObject obj)
    {
        targeted = obj.GetComponent<TargetedTrigger>();
        targeted.abilityObject = abilityObject;
        targeted.range = range;
    }

    /// <summary>
    /// Cast ability using monobehavior handlers. Used to cast generic
    /// abilities. More complicated things may not be able to be done here.
    /// </summary>
    public override void cast()
    {
        targeted.cast(effect);
    }
}

