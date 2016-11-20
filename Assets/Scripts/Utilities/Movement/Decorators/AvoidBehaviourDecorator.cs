// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;
using System;

public class AvoidBehaviourDecorator : ActiveBehaviourDecorator
{
    new AvoidBehaviour behaviour;

    public AvoidBehaviourDecorator(AbstractBehaviourComponent parentBehaviour, MovementBehaviour behaviour)
    : base(parentBehaviour, behaviour) { this.behaviour = behaviour as AvoidBehaviour; }


    public override Vector3 Steering()
    {
        // raycast to find if something is in front
        RaycastHit hit;
        var distance = behaviour.maxDistance * (agentProperties.CurrentVelocity.magnitude / agentProperties.MaximumSpeed);

        if (Physics.Raycast(agentProperties.CurrentPosition, agentProperties.CurrentVelocity, out hit, distance))
        {
            var hitAgent = hit.collider.gameObject.GetComponent<AgentManager>();
            Vector3 direction;

            // if the hit is moving, steering in the opposite direction as its velocity.
            if (hitAgent.mover.CurrentVelocity.magnitude >= 0.05f)
            {
                direction = hitAgent.mover.CurrentVelocity.normalized * -1;
            }
            else
            {
                direction = Vector3.Cross(Vector3.up, agentProperties.CurrentVelocity).normalized;
            }

            var velocity = hitAgent.transform.position + (direction * (hitAgent.GetComponent<SphereCollider>().radius + 2));
            velocity = velocity.normalized * agentProperties.MaximumSpeed;

            var steering = (velocity - agentProperties.CurrentVelocity) * behaviour.Priority;
            return steering + parentBehaviour.Steering();
        }

        return parentBehaviour.Steering();
    }


}
