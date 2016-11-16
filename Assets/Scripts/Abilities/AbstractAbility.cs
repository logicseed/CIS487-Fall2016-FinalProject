/// <summary>
///  Base class used to create abilities. Any combination of the things below.
///  1. Skill shots
///  2. Area of effect
///  3. Point and click
///  4. Innate(Passives)
/// </summary>

using UnityEngine;
using System.Collections;

public abstract class AbstractAbility : ScriptableObject
{
    //Power Shield - Enhance shield for a short time
    //Power Beam - Emit a high damage beam
    //Ion Burst - Release a shield destroying ion pulse form ship
    //Power Ram - Charge your ship into another for high damage
    //Overcharge Guns - Charge auto attack turrets for extra damage
    //Cloak Field - Release a temporary cloak field to stop ships from targeting
    //Concussive Missiles - Hit ship is slowed and disoriented for a short time
    //Smart Bomb - Launch a bomb that explodes creating a huge blast radius
    //Lay Mine - Release a mine that explodes on contact
    //Over Charge Engines - Charge engines for more speed for a short time
    //Power Blast - Fire a powerful high damage shot
    //Tractor Beam - Attach your ship to another forcing a set distance between

    //For ability classification
    public new string name = "New ability name";
    public string description = "New description";
    public int effect;  //Retrieve value from AbilityList enum

    //Required components for any ability
    public GameObject abilityObject; //Has many forms
    public float range;

    //Skill shots
    [HideInInspector] public Vector3 velocity; //Speed and direction of projectile

    //AOE
    public float aoeRadius; //Size of aoe
    [HideInInspector] public Transform aoeLocation;  //Location for aoe

    //Point and click
    [HideInInspector] public GameObject target;

    /// <summary>
    /// Create and cast ability sequences
    /// </summary>
    public abstract void cast();
    public abstract void initialize(GameObject obj);
}