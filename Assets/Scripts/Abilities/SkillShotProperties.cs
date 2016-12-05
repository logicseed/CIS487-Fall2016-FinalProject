using UnityEngine;
using System.Collections;

/// <summary>
/// Properties for a blast skill shot ability behavior
/// Create a new unity ability asset: Assets --> Create --> Ability --> New Skill shot ability
/// </summary>
[CreateAssetMenu(menuName = "Ability/New Skill shot ability")]
public class SkillShotProperties : Ability
{
    SkillShotBehavior skill;
    public GameObject abilityObject;
    public float maxCastRange;
    public float force;

    /// <summary>
    /// Give the information from the scriptable object to the monobehavior handler. 
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(GameObject obj)
    {
        skill = obj.GetComponent<SkillShotBehavior>();
        skill.abilityObject = abilityObject;
        skill.maxRange = maxCastRange;
        skill.force = force;
    }

    /// <summary>
    /// Cast ability using monobehavior handler. 
    /// </summary>
    public override void cast()
    {
        skill.cast();
    }
}
