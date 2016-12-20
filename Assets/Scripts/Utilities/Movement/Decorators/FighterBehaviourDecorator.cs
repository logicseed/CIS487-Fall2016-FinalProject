// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;
using System;

public class FighterBehaviourDecorator : ActiveBehaviourDecorator
{
    new FighterBehaviour behaviour;

    public FighterBehaviourDecorator(AbstractBehaviourComponent parentBehaviour, MovementBehaviour behaviour)
    : base(parentBehaviour, behaviour) { this.behaviour = behaviour as FighterBehaviour; }

    public override Vector3 Steering(bool debugRays = false)
    {
        //Debug.Log("Executing fighter steering");
        if (Deleting()) return parentBehaviour.Steering();
        
        var velocityVector = behaviour.target.transform.position - agent.position;
        var desiredVelocity = velocityVector.normalized * agent.mover.maxSpeed;

        var distance = velocityVector.magnitude;
        if (distance < behaviour.approachRadius)
            desiredVelocity *= (distance / behaviour.approachRadius);

        var steering = (desiredVelocity - agent.mover.velocity);
        var prioritySteering = steering * behaviour.priority;

        if (debugRays)
        {
            Debug.DrawRay(agent.position, velocityVector, MaterialColor.Grey);
            Debug.DrawRay(agent.position + agent.mover.velocity,
                          prioritySteering, MaterialColor.Grey);

            Debug.DrawRay(agent.position, desiredVelocity, MaterialColor.Standard.SeekDesiredVelocity);
            Debug.DrawRay(agent.position + agent.mover.velocity,
                          steering, MaterialColor.Standard.SeekSteering);
        }

        return steering + parentBehaviour.Steering(debugRays);
    }

    public bool Deleting()
    {
        if (DeleteIfTargetNull())
        {
            behaviour.OnDeleteBehaviour();
            return true;
        }
        return false;
    }

    protected bool DeleteIfTargetNull()
    {
        return behaviour.deleteWhenNull && behaviour.target == null;
    }
}
