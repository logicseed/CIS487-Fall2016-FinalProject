using UnityEngine;
using System.Collections;

public class Self :  AbstractAbility
{
    private SelfTrigger self;

    /// <summary>
    /// Give the information from the scriptable object to the monobehavior
    /// handlers. 
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(GameObject obj)
    {
        self = obj.GetComponent<SelfTrigger>();
        self.abilityObject = abilityObject;
    }

    /// <summary>
    /// cast ability using monobehavior handlers. Used to cast generic
    /// abilities. More complicated things may not be able to be done here.
    /// </summary>
    public override void cast()
    {
        self.cast(effect);
    }
}