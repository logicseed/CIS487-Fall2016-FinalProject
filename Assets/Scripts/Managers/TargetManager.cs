﻿// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Manages the targets of an agent.
/// </summary>
[RequireComponent(typeof(AgentManager))]
[DisallowMultipleComponent]
public class TargetManager : NetworkBehaviour
{
    //[HideInInspector]
    public AgentManager agent;
    //[HideInInspector]
    
    public AgentManager direct;
    //[HideInInspector]
    public GameObject directIndicator;
    //[HideInInspector]
    public AgentManager location;

    void Start()
    {

    }

    private bool hasSetup = false;
    public void Setup(AgentManager agent)
    {
        // Single execution
        if (hasSetup) return;
        hasSetup = true;

        this.agent = agent;
    }

    void Update()
    {
        // If close to location target, remove the location target.
        if (location != null)
        {
            var distance = Vector3.Distance(agent.position, location.position);
            if (distance <= 0.5f) RemoveLocationTarget();
        }

        if (direct != null && direct.team == agent.team) RemoveDirectTarget();
    }

    /// <summary>
    /// Sets the location target to a Vector3 position.
    /// </summary>
    /// <returns>True if set; false otherwise.</returns>
    public void SetLocationTarget(Vector3 position)
    {
        //Debug.Log("Setting a location target: " + position);
        if (location != null) Destroy(location.gameObject);

        // create location target agent
        var graphic = Instantiate(Resources.Load("TargetSelectionLocation")) as GameObject;
        location = graphic.GetComponent<AgentManager>();
        location.position = position;
    }

    /// <summary>
    /// Removes the location target.
    /// </summary>
    /// <returns>True if removed; false otherwise.</returns>
    public void RemoveLocationTarget()
    {
        Destroy(location.gameObject);
        location = null;
    }

    /// <summary>
    /// Sets the direct target to a type and game object.
    /// </summary>
    /// <param name="type">The type of target.</param>
    /// <param name="target">The game object of the target.</param>

    [Command]
    public void CmdSetDirectTarget(GameObject target)
    {
        SetDirectTarget(target);
    }

    [Server]
    public void SetDirectTarget(GameObject target)
    {
        RpcSetDirectTarget(target);
    }

    [ClientRpc]
    public void RpcSetDirectTarget(GameObject target)
    {
        if (agent.type == AgentType.Player)
        {
            if (direct != null) RemoveDirectTarget();

            directIndicator = Instantiate(Resources.Load("TargetSelectionAlly")) as GameObject;
            directIndicator.transform.parent = target.transform;
            directIndicator.transform.localPosition = Vector3.zero;
            var scale = 4 * target.GetComponent<AgentManager>().sphere.radius;
            directIndicator.transform.localScale = new Vector3(scale, scale, scale);
        }
        direct = target.GetComponent<AgentManager>();
    }

    /// <summary>
    /// Removes the direct target.
    /// </summary>
    public void RemoveDirectTarget()
    {
        Destroy(directIndicator);
        direct = null;
    }
}
