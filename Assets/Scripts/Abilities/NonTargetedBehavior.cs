using UnityEngine;
using System.Collections;

public class NonTargetedBehavior : MonoBehaviour
{
    [HideInInspector]
    public GameObject abilityObject;
    [HideInInspector]
    public float maxRange;

    public Transform abilitySpawnLoc;
    AgentManager agent;
    AgentManager objectAgent;

    void Start()
    {
        agent = GetComponent<AgentManager>();
    }

    public void cast()
    {
        GameObject instantiatedObject;

        if (maxRange == 0)
            instantiatedObject = (GameObject)Instantiate(abilityObject, abilitySpawnLoc.transform.position, transform.rotation);
        else if(Vector3.Distance(gameObject.transform.position, FindMousePosition()) <= maxRange)
        {
            instantiatedObject = (GameObject)Instantiate(abilityObject, abilitySpawnLoc.transform.position, transform.rotation);
            instantiatedObject.transform.position = FindMousePosition();
        }
        objectAgent = GetComponent<AgentManager>();
        objectAgent.SendMessage("Start");
        objectAgent.team = agent.team;
        objectAgent.type = AgentType.AbilityEffect;
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
