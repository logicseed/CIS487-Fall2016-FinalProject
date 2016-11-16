using UnityEngine;
using System.Collections;
using System;

//Assets-->Create-->Abilities-->New ability
[CreateAssetMenu(menuName = "Abilities/New Ability")] 
public class TestAbility : AbstractAbility
{
    private SkillShot skill;
    private AreaOfEffect aoe;
    private PointClick point;
    
    /// <summary>
    /// Give the information from the scriptable object to the monobehavior
    /// handlers. 
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(GameObject obj)
    {
        skill = obj.GetComponent<SkillShot>();
        aoe = obj.GetComponent<AreaOfEffect>();
        point = obj.GetComponent<PointClick>();

        aoe.abilityObject = abilityObject;
        aoe.aoeRadius = aoeRadius;
        aoe.range = range;
    }

    /// <summary>
    /// cast ability using monobehavior handlers. Used to cast generic
    /// abilities. More complicated things may not be able to be done here.
    /// </summary>
    public override void cast()
    {
        //skill.cast();
        aoe.cast();
        //point.cast();
    }
}