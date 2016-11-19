// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TargetManager))]
[DisallowMultipleComponent]
public class MouseController : MonoBehaviour 
{
    private AgentManager agent;
    
    // Use this for initialization
    void Start ()
    {
        agent = gameObject.GetComponent<AgentManager>();
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject target = FindTarget();

            if (target != null)
            {
                agent.target.SetDirectTarget(TargetType.Ally, target);
            }
            else if (target == null)
            {
                agent.target.SetLocationTarget(FindMousePosition());

                MovementBehaviour behaviour = new SeekBehaviour(agent.target.location.graphicGameObject.transform,true);
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
        if (Physics.Raycast (ray, out hit, 100.0f))
        {
            
            Debug.Log("You selected the " + hit.transform.name);
            return hit.transform.gameObject;
        }
        return null;
    }
}
