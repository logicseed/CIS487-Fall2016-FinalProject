/// <summary>
///  Base class used to create abilities. Any combination of the things below.
///  1. Skill shots
///  2. Area of effect
///  3. Point and click
///  4. Innate(Passives)
/// </summary>

using UnityEngine;

public abstract class AbstractAbility : MonoBehaviour //Remove MonoBehavior and use ability manager?
{
    //For ability classification
    protected string description;
    protected int effect;  //Retrieve value from AbilityList enum

    //Required components for any ability
    public GameObject projectile;
    public int cost;
    public float cooldown;
    public float range;
    public float timeToDestory; //Destroy gameobject after seconds
 
    //Skill shots
    protected Vector3 velocity; //Speed and direction of projectile

    //AOE
    public float aoeRadius; //Size of aoe
    protected Transform aoeLocation;  //Location for aoe

    //Point and click
    protected GameObject target;

    /// <summary>
    /// Create and cast ability sequences
    /// </summary>
    public abstract void cast();
    public abstract void destroyCast();
}