﻿// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.Networking;

public class GraphicsManager : NetworkBehaviour
{
    [HideInInspector]
    public AgentManager agent;
    [HideInInspector]
    public GameObject graphicsGO;

    public void Setup(AgentManager agent)
    {
        this.agent = agent;
        this.graphicsGO = transform.Find("Graphics").gameObject;

        ApplyTeamColors();
    }

    private void FixedUpdate()
    {
        UpdateGraphicsHeading();
    }

    /// <summary>
    /// 
    /// </summary>
    public void ApplyTeamColors()
    {
        if (agent.team != TeamType.World)
        {
            var teamColor = GameManager.Instance.GetTeamColor(agent.team);
            var renderers = gameObject.GetComponentsInChildren(typeof(Renderer));

            foreach (Renderer renderer in renderers)
            {
                renderer.material.SetColor("_Color", Color.Lerp(Color.white, teamColor, 0.2f) * 0.5f);
                renderer.material.SetColor("_EmissionColor", teamColor * 10.0f);
            }
        }
    }

    /// <summary>
    /// Updates the <see cref="GameObject"/> that represent the graphics for this mover to face 
    /// to correct heading for the mover's current velocity.
    /// </summary>
    private void UpdateGraphicsHeading()
    {
        if (graphicsGO != null)
        {
            var targetDir = agent.mover.heading;

            var newDir = Vector3.RotateTowards(
                graphicsGO.transform.forward,
                targetDir,
                Time.fixedDeltaTime * 10, 0.0f);

            graphicsGO.transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}
