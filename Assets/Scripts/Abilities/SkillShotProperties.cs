using UnityEngine;
using System.Collections;

//Assets-->Create-->Abilities-->New ability
[CreateAssetMenu(menuName = "Ability/New Skill shot ability")]
public class SkillShotProperties : Ability
{
    private SkillShotBehavior skill;
    public float force;

    /// <summary>
    /// Give the information from the scriptable object to the monobehavior
    /// handlers. 
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
    /// cast ability using monobehavior handlers. Used to cast generic
    /// abilities. More complicated things may not be able to be done here.
    /// </summary>
    public override void cast()
    {
        skill.cast();
    }
}
