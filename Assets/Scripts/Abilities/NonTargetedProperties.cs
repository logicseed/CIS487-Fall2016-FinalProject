using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Ability/New Non targeted ability")]
public class NonTargetedProperies : Ability
{
    private NonTargetedBehavior nonTargeted;

    /// <summary>
    /// Give the information from the scriptable object to the monobehavior
    /// handlers. 
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(GameObject obj)
    {
        nonTargeted = obj.GetComponent<NonTargetedBehavior>();
        nonTargeted.abilityObject = abilityObject;
        nonTargeted.maxRange = maxRange;
    }

    /// <summary>
    /// cast ability using monobehavior handlers. Used to cast generic
    /// abilities. More complicated things may not be able to be done here.
    /// </summary>
    public override void cast()
    {
        nonTargeted.cast();
    }
}
