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
        // find nearby colliders
        // find closest collider in path








        // raycast to find if something is in front
        RaycastHit hit;

        var rayDistance = (behaviour.maxDistance * agentProperties.MaximumSpeed) *
            (agentProperties.CurrentVelocity.magnitude / agentProperties.MaximumSpeed);

        if (Physics.SphereCast(agentProperties.CurrentPosition, behaviour.sphereRadius, agentProperties.CurrentVelocity,
            out hit, rayDistance))
        //if (Physics.Raycast(agentProperties.CurrentPosition, agentProperties.CurrentVelocity, out hit, rayDistance))
        {
            var hitAgent = hit.collider.gameObject.GetComponent<AgentManager>();
            Vector3 direction;

            // if the hit is moving, steering in the opposite direction as its velocity.
            //if (hitAgent.mover.CurrentVelocity.magnitude >= 0.05f)
            //{
            //    direction = hitAgent.mover.CurrentVelocity.normalized * -1;
            //}
            //else
            //{
            //    direction = Vector3.Cross(Vector3.up, agentProperties.CurrentVelocity).normalized;
            //}

            direction = hit.point - hitAgent.position;


            //var velocity = hitAgent.transform.position + (direction * (hitAgent.GetComponent<SphereCollider>().radius + 2));
            //velocity = velocity.normalized * agentProperties.MaximumSpeed;

            //var steering = (velocity - agentProperties.CurrentVelocity) * behaviour.Priority;


            var steering = (direction.normalized * agentProperties.MaximumSteering) * behaviour.Priority;

            if (debugRays)
            {
                // target
                Debug.DrawRay(agentProperties.CurrentPosition, hit.transform.position - agentProperties.CurrentPosition,
                              RayColor.Grey);

                // look ahead
                Debug.DrawRay(agentProperties.CurrentPosition, agentProperties.CurrentVelocity.normalized * rayDistance,
                          RayColor.Standard.AvoidRayDistance);

                // steering
                Debug.DrawRay(agentProperties.CurrentPosition + agentProperties.CurrentVelocity,
                              steering, RayColor.Standard.AvoidSteering);
            }

            return steering;
            //return steering + parentBehaviour.Steering(debugRays);
        }

        if (debugRays)
        {
            Debug.DrawRay(agentProperties.CurrentPosition, agentProperties.CurrentVelocity.normalized * rayDistance,
                          RayColor.Standard.AvoidRayDistance);
        }

        return parentBehaviour.Steering(debugRays);
    }


}
