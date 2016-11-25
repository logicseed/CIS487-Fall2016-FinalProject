using UnityEngine;
using System.Collections;

public class TargetedBehavior : MonoBehaviour
{
    public Transform abilitySpawnLoc;
    [HideInInspector]
    public GameObject abilityObject;
    [HideInInspector]
    public float maxRange;

    AgentManager agent;
    AgentManager objectAgent;

    void Start()
    {
        agent = gameObject.GetComponent<AgentManager>();
    }

    public void cast()
    {
        if (Vector3.Distance(gameObject.transform.position, FindMousePosition()) <= maxRange)
        {
            GameObject instantiatedObject = (GameObject)Instantiate(abilityObject, abilitySpawnLoc);
            objectAgent = instantiatedObject.GetComponent<AgentManager>();
            objectAgent.SendMessage("Start");

            MovementBehaviour behaviour = new PursueBehaviour(agent.target.agent, true);
            objectAgent.mover.AddBehaviour(behaviour);

            //objectAgent.mover.props.MaximumSpeed = 20.0f;
            //objectAgent.mover.props.MaximumSteering = 3.0f;
        }
    }

    private Vector3 FindMousePosition()
    {
        var plane = new Plane(Vector3.up, transform.position);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance = 0.0f;

        if (plane.Raycast(ray, out distance))
        {
            var location = ray.GetPoint(distance);
            return location;
        }
        return Vector3.zero;
    }
}
