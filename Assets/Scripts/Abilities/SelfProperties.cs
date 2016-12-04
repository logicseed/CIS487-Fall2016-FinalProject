using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BuffTypes
{
    Shields,
    AttackSpeed,
    AttackDamage,
    MovementSpeed
}

[CreateAssetMenu(menuName = "Ability/New Self ability")]
public class SelfProperties :  Ability
{
    private SelfBehavior self;
    public List<buff> buffList;

    [System.Serializable]
    public struct buff
    {
        public BuffTypes effect;
        public float duration;
        public float magnitude;
    }

    /// <summary>
    /// Give the information from the scriptable object to the monobehavior
    /// handlers. 
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(GameObject obj)
    {
        self = obj.GetComponent<SelfBehavior>();
        self.buffList = buffList;
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