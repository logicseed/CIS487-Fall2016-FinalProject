using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Enum list for all different possible buff types
public enum BuffTypes
{
    Shields,
    AttackSpeed,
    AttackDamage,
    MovementSpeed
}

/// <summary>
/// Properties for self ability behavior
/// Create a new unity ability asset: Assets --> Create --> Ability --> New Self ability
/// </summary>
[CreateAssetMenu(menuName = "Ability/New Self ability")]
public class SelfProperties :  Ability
{
    SelfBehavior self;
    public List<buff> buffList;

    // Struct that has information on what a buff should have.
    // These will be added and modified on the unity asset.
    [System.Serializable]
    public struct buff
    {
        public BuffTypes effect;
        public float duration;
        public float magnitude;
    }

    /// <summary>
    /// Give the information from the scriptable object to the monobehavior handler. 
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(GameObject obj)
    {
        self = obj.GetComponent<SelfBehavior>();
        self.buffList = buffList;
    }

    /// <summary>
    /// Cast ability using monobehavior handler. 
    /// </summary>
    public override void cast()
    {
        self.cast();
    }
}