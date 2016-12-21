using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NonTargetedBehavior : NetworkBehaviour
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
        ClientScene.RegisterPrefab(abilityObject);
    }

    [Command]
    public void cast()
    {
        GameObject instantiatedObject;

        if (maxRange == 0)
        {
            instantiatedObject = (GameObject)Instantiate(abilityObject, abilitySpawnLoc.transform.position, transform.rotation);
            NetworkServer.Spawn(instantiatedObject); //Network spawn
        }
        else if (Vector3.Distance(gameObject.transform.position, FindMousePosition()) <= maxRange)
        {
            instantiatedObject = (GameObject)Instantiate(abilityObject, abilitySpawnLoc.transform.position, transform.rotation);
            instantiatedObject.transform.position = FindMousePosition();
            NetworkServer.Spawn(instantiatedObject); //Network spawn
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
