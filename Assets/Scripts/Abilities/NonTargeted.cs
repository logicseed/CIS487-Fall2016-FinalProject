using UnityEngine;
using System.Collections;

//Assets-->Create-->Abilities-->New ability
[CreateAssetMenu(menuName = "Abilities/New Non targeted")]
public class NonTargeted : AbstractAbility
{
    private NonTargetedTrigger noTarget;

    /// <summary>
    /// Give the information from the scriptable object to the monobehavior
    /// handlers. 
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(GameObject obj)
    {
        noTarget = obj.GetComponent<NonTargetedTrigger>();
        noTarget.abilityObject = abilityObject;
        noTarget.range = range;
    }

    /// <summary>
    /// cast ability using monobehavior handlers. Used to cast generic
    /// abilities. More complicated things may not be able to be done here.
    /// </summary>
    public override void cast()
    {
        noTarget.cast();
    }
}
