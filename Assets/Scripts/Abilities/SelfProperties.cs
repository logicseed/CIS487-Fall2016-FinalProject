using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Ability/New Self ability")]
public class SelfProperties :  Ability
{
    private SelfBehavior self;

    public enum toBuff
    {
        Shields,
        AttackSpeed,
        AttackDamage,
        MovementSpeed
    }

    public List <toBuff> buffList;
    public List<float> duration;

    /// <summary>
    /// Give the information from the scriptable object to the monobehavior
    /// handlers. 
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(GameObject obj)
    {
        self = obj.GetComponent<SelfBehavior>();
        self.duration = duration;
        self.buffList = buffList;

        //foreach (var effect in buff)
        //{
        //    self.buff.Add(effect.ToString());
        //}
    }

    /// <summary>
    /// cast ability using monobehavior handlers. Used to cast generic
    /// abilities. More complicated things may not be able to be done here.
    /// </summary>
    public override void cast()
    {
        self.cast();
    }
}