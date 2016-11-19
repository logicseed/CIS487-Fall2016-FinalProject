using UnityEngine;
using System.Collections;

//Assets-->Create-->Abilities-->New ability
[CreateAssetMenu(menuName = "Abilities/New Skill shot")]
public class SkillShot : AbstractAbility
{
    private SkillShotTrigger skill;
    public float force;

    /// <summary>
    /// Give the information from the scriptable object to the monobehavior
    /// handlers. 
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(GameObject obj)
    {
        skill = obj.GetComponent<SkillShotTrigger>();
        skill.abilityObject = abilityObject;
        skill.range = range;
        skill.force = force;
    }

    /// <summary>
    /// cast ability using monobehavior handlers. Used to cast generic
    /// abilities. More complicated things may not be able to be done here.
    /// </summary>
    public override void cast()
    {
        skill.cast(effect);
    }
}
