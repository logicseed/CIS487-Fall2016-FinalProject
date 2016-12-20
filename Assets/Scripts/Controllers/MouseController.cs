// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public class MouseController : NetworkBehaviour 
{  
    void Update()
    {
        if (!isLocalPlayer) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject target = FindTarget();

            if (target != null)
            {
                CmdSetDirectTarget(target);
            }
            else if (target == null)
            {
                CmdSetLocationTarget(FindMousePosition());
            }
        }
    }

    //[Command]
    void CmdSetLocationTarget(Vector3 position)
    {
        var agent = gameObject.GetComponent<AgentManager>();

        agent.target.SetLocationTarget(position);

        MovementBehaviour behaviour = new SeekBehaviour(agent.target.location,true);
        agent.mover.AddBehaviour(behaviour);
    }

    //[Command]
    public void CmdSetDirectTarget(GameObject target)
    {
        var agent = gameObject.GetComponent<AgentManager>();
        agent.target.CmdSetDirectTarget(target);
    }

    private Vector3 FindMousePosition()
    {
        var plane = new Plane(Vector3.up, transform.position);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            var location = ray.GetPoint(distance);
            //Debug.Log("You clicked at " + location);
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
            
            //Debug.Log("You selected the " + hit.transform.name);
            return hit.transform.gameObject;
        }
        return null;
    }
}
