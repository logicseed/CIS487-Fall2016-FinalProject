// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;
using System;

public class AvoidBehaviourDecorator : ActiveBehaviourDecorator
{
    new AvoidBehaviour behaviour;

    public AvoidBehaviourDecorator(AbstractBehaviourComponent parentBehaviour, MovementBehaviour behaviour)
    : base(parentBehaviour, behaviour)
    {
        this.behaviour = behaviour as AvoidBehaviour;
        this.agent = parentBehaviour.agent;
    }


    public override Vector3 Steering(bool debugRays = false)
    {
        var steering = Vector3.zero;
        var layerMask = LayerMask.GetMask("Environment");

        // avoid obstacles in front
        RaycastHit hit;

        var rayDistance = (behaviour.maxDistance * agent.mover.maxSpeed) *
            (agent.mover.velocity.magnitude / agent.mover.maxSpeed);

        if (Physics.SphereCast(agent.position, behaviour.sphereRadius, agent.mover.velocity, out hit, rayDistance, layerMask))
        {
            var hitAgent = hit.collider.gameObject.GetComponent<AgentManager>();
            var direction = hit.point - hitAgent.position;

            steering = (direction.normalized * agent.mover.maxSpeed);

            if (debugRays)
            {
                // target
                Debug.DrawRay(agent.position, hit.transform.position - agent.position, MaterialColor.Grey);

                // look ahead
                Debug.DrawRay(agent.position, agent.mover.velocity.normalized * rayDistance, MaterialColor.Standard.AvoidRayDistance);

                // steering
                Debug.DrawRay(agent.position + agent.mover.velocity, steering, MaterialColor.Standard.AvoidSteering);
            }

        }

        // avoid obstacles around
        var hitColliders = Physics.OverlapSphere(agent.position, behaviour.personalSpace, layerMask);

        foreach(SphereCollider hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.transform.position == agent.position) continue;

            //var hitAgent = hitCollider.gameObject.GetComponent<AgentManager>();
            //Debug.Log("Agent Position: " + agent.position);
            //Debug.Log("Collider Position: " + hitCollider.transform.position);
            var direction = hitCollider.transform.position - agent.position;
            var distance = Mathf.Abs(direction.magnitude) - (hitCollider.radius + behaviour.personalSpace);
            //Debug.Log("Distance: " + distance);
            direction.Normalize();

            var importance = behaviour.personalSpace / distance;
            //Debug.Log("Importance: " + importance);

            steering += (direction * agent.mover.maxAccel) * importance;
        }





        if (debugRays)
        {
            Debug.DrawRay(agent.position, agent.mover.velocity.normalized * rayDistance,
                          MaterialColor.Standard.AvoidRayDistance);
        }

        steering *= behaviour.priority;
        return steering + parentBehaviour.Steering(debugRays);
    }


}
