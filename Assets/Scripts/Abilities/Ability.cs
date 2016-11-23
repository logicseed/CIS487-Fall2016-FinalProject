/// <summary>
///  Base class used to create abilities. Any combination of the things below.
///  1. Skill shots
///  2. Area of effect
///  3. Point and click
///  4. Innate(Passives)
/// </summary>

using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public abstract class Ability : ScriptableObject
{
    //Tractor Beam - Attach your ship to another forcing a set distance between  -- Point click (???)
    //Smart Bomb - Launch a bomb that explodes creating a huge blast radius      -- Point click (damage)
    //Power Beam - Emit a high damage beam                                       -- Point click (damage)

    //Lay Mine - Release a mine that explodes on contact                         -- Nontargetted (at loc/damage)
    //Gravity well - Place a large gravity well nearby, suck in other players    -- Nontargetted (at loc/slow)
    //Ion Burst - Release a shield destroying ion pulse form ship                -- Nontargetted (on self)
    //Cloak Field - Release a temporary cloak field to stop ships from targeting -- Nontargetted (on self)

    //Concussive Missiles - Hit ship is slowed and disoriented for a short time  -- Skill shot (debuff)
    //Power Blast - Fire a powerful high damage shot                             -- Skill shot (damage)
    //Power Ram - Charge your ship into another for high damage                  -- Skill shot (buff/damage)

    //Overcharge Guns - Charge auto attack turrets for extra damage              -- Self (buff)
    //Power Shield - Enhance shield for a short time                             -- Self (buff)
    //OverCharge Engines - Charge engines for more speed for a short time        -- Self (buff)

    public new string name = "New ability name";
    public string description = "New description";
    public List<int> effectList;  //Retrieve value from AbilityList enum
    public GameObject abilityObject;
    public GameObject abilitySpawnLoc;
    public float maxRange;

    /// <summary>
    /// Create and cast ability sequences
    /// </summary>
    public abstract void cast();
    public abstract void initialize(GameObject obj);
}