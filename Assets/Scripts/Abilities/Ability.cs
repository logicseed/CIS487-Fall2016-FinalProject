﻿using UnityEngine;
using System.Collections.Generic;

/// <summary>
///  Base class used to create abilities. These are used to determine the initial spawn behavior 
///  of the instantiated object or behavior that will act on the player.
///  1. Targeted - Fire an object that will follow the direct target
///  2. NonTargeted - Place an object in open space or drop off some ship depending on range
///  3. Skill shot - Object travels along a path towards a target location
///  4. Self - Action that only effects the casting player
///  5. Contact - An object attached to player ship that will contact another ship
/// </summary>

[System.Serializable]
public abstract class Ability : ScriptableObject
{
    // All abilities consist of these attributes.
    public new string name = "New ability name";
    public string description = "New description";
    public float cooldown;

    // Abstract cast and initialize used by different ability types.
    public abstract void cast();
    // Obj is the player object that the ability behavior will be attached to.
    public abstract void initialize(GameObject obj);
}

//Tractor Beam - Attach your ship to another forcing a set distance between  -- Point click (CC)
//Smart Bomb - Launch a bomb that explodes creating a huge blast radius      -- Point click (damage)
//Power Beam - Emit a high damage beam                                       -- Point click (damage)

//Lay Mine - Release a mine that explodes on contact                         -- Nontargetted (at loc/damage)
//Gravity well - Place a large gravity well nearby to suck in other players  -- Nontargetted (at loc/slow)
//Ion Burst - Release a shield destroying ion pulse form ship                -- Nontargetted (on self)
//Cloak Field - Release a temporary cloak field to stop ships from targeting -- Nontargetted (on self)

//Concussive Missiles - Hit ship is slowed and disoriented for a short time  -- Skill shot (debuff)
//Power Blast - Fire a powerful high damage shot                             -- Skill shot (damage)
//Power Ram - Charge your ship into another for high damage                  -- Contact    (buff/damage)

//Overcharge Guns - Charge auto attack turrets for extra damage              -- Self (buff)
//Power Shield - Enhance shield for a short time                             -- Self (buff)
//OverCharge Engines - Charge engines for more speed for a short time        -- Self (buff)