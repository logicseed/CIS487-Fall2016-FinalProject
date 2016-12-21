using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SelfBehavior : MonoBehaviour
{
    [HideInInspector]
    public List<SelfProperties.buff> buffList;

    AgentManager agent;
    AutoAttack auto;
    IEnumerator coroutine;

    void start()
    {
        agent = gameObject.GetComponent<AgentManager>();
        auto = gameObject.GetComponent<AutoAttack>();
    }

    public void cast()
    {
        foreach (var buff in buffList)
        {
            switch (buff.effect)
            {
                case BuffTypes.AttackSpeed:
                    coroutine = applyAttackSpeed(buff.duration, buff.magnitude);
                    StartCoroutine("coroutine");
                    break;
                case BuffTypes.MovementSpeed:
                    coroutine = applyAttackSpeed(buff.duration, buff.magnitude);
                    StartCoroutine("coroutine");
                    break;
                case BuffTypes.Shields:
                    coroutine = applyAttackSpeed(buff.duration, buff.magnitude);
                    StartCoroutine("coroutine");
                    break;
            }
        }
    }

    IEnumerator applyAttackSpeed(float duration, float magnitude)
    {
        float temp = auto.timeBetweenAttacks;
        auto.timeBetweenAttacks = auto.timeBetweenAttacks - magnitude;
        yield return new WaitForSeconds(duration);
        auto.timeBetweenAttacks = temp;
    }

    IEnumerator applyMovementSpeed(float duration, float magnitude)
    {
        float maxSpeedTemp = agent.mover.maxSpeed;
        float maxSteeringTemp = agent.mover.maxAccel;
        agent.mover.maxSpeed = agent.mover.maxSpeed + magnitude;
        agent.mover.maxSpeed = agent.mover.maxAccel + (magnitude * 0.25f);
        yield return new WaitForSeconds(duration);
        agent.mover.maxSpeed = maxSpeedTemp;
        agent.mover.maxSpeed = maxSteeringTemp;
    }

    IEnumerator applyShields(float duration, float magnitude)
    {
        float maxShield = agent.maximumShields;
        agent.maximumShields = agent.maximumShields + (int)magnitude;
        agent.shields = agent.shields + (agent.maximumShields - agent.shields);
        yield return new WaitForSeconds(duration);
        agent.shields = maxShield;
        agent.maximumShields = maxShield;
    }
}
