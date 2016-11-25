// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(TargetManager))]
[DisallowMultipleComponent]
public class MouseController : NetworkBehaviour 
{
    [HideInInspector]
    public AgentManager agent;
    
    // Use this for initialization
    void Start ()
    {
        agent = gameObject.GetComponent<AgentManager>();
    }
    
    // Update is called once per frame
    void Update () {
        if (!isLocalPlayer) return;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject target = FindTarget();

            if (target != null)
            {
                agent.target.SetDirectTarget(target.GetComponent<AgentManager>());
            }
            else if (target == null)
            {
                agent.target.SetLocationTarget(FindMousePosition());

                MovementBehaviour behaviour = new SeekBehaviour(agent.target.location,true);
                agent.mover.AddBehaviour(behaviour);
            }
        }
    }

    private Vector3 FindMousePosition()
    {
        var plane = new Plane(Vector3.up, transform.position);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            var location = ray.GetPoint(distance);
            Debug.Log("You clicked at " + location);
            return location;
        }
        return Vector3.zero;
    }

    private GameObject FindTarget()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit, 1000.0f))
        {
            
            Debug.Log("You selected the " + hit.transform.name);
            return hit.transform.gameObject;
        }
        return null;
    }
}
