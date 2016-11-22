// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;
using System;

public class AvoidBehaviourDecorator : ActiveBehaviourDecorator
{
    new AvoidBehaviour behaviour;

    public AvoidBehaviourDecorator(AbstractBehaviourComponent parentBehaviour, MovementBehaviour behaviour)
    : base(parentBehaviour, behaviour) { this.behaviour = behaviour as AvoidBehaviour; }


    public override Vector3 Steering(bool debugRays = false)
    {
        var steering = Vector3.zero;

        // avoid obstacles in front
        RaycastHit hit;

        var rayDistance = (behaviour.maxDistance * agentProperties.MaximumSpeed) *
            (agentProperties.CurrentVelocity.magnitude / agentProperties.MaximumSpeed);

        if (Physics.SphereCast(agentProperties.CurrentPosition, behaviour.sphereRadius, agentProperties.CurrentVelocity, out hit, rayDistance))
        {
            var hitAgent = hit.collider.gameObject.GetComponent<AgentManager>();
            var direction = hit.point - hitAgent.position;

            steering = (direction.normalized * agentProperties.MaximumSteering);

            if (debugRays)
            {
                // target
                Debug.DrawRay(agentProperties.CurrentPosition, hit.transform.position - agentProperties.CurrentPosition, RayColor.Grey);

                // look ahead
                Debug.DrawRay(agentProperties.CurrentPosition, agentProperties.CurrentVelocity.normalized * rayDistance, RayColor.Standard.AvoidRayDistance);

                // steering
                Debug.DrawRay(agentProperties.CurrentPosition + agentProperties.CurrentVelocity, steering, RayColor.Standard.AvoidSteering);
            }

        }

        // avoid obstacles around
        var hitColliders = Physics.OverlapSphere(agentProperties.CurrentPosition, behaviour.personalSpace);

        foreach(SphereCollider hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.transform.position == agentProperties.CurrentPosition) continue;

            //var hitAgent = hitCollider.gameObject.GetComponent<AgentManager>();
            Debug.Log("Agent Position: " + agentProperties.CurrentPosition);
            Debug.Log("Collider Position: " + hitCollider.transform.position);
            var direction = hitCollider.transform.position - agentProperties.CurrentPosition;
            var distance = Mathf.Abs(direction.magnitude) - (hitCollider.radius + behaviour.personalSpace);
            Debug.Log("Distance: " + distance);
            direction.Normalize();

            var importance = behaviour.personalSpace / distance;
            Debug.Log("Importance: " + importance);

            steering += (direction * agentProperties.MaximumSteering) * importance;
        }





        if (debugRays)
        {
            Debug.DrawRay(agentProperties.CurrentPosition, agentProperties.CurrentVelocity.normalized * rayDistance,
                          RayColor.Standard.AvoidRayDistance);
        }

        steering *= behaviour.Priority;
        return steering + parentBehaviour.Steering(debugRays);
    }


}
