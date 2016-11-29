// Marc King - mjking@umich.edu

using UnityEngine;

public class GraphicsManager : MonoBehaviour
{
    private AgentManager agent;
    private GameObject graphicsGameObject;

    private void Start()
    {
        agent = gameObject.GetComponent<AgentManager>();

        CreateGraphicsGameObject();
        ApplyTeamColors();
    }

    private void FixedUpdate()
    {
        UpdateGraphicsHeading();
    }

    /// <summary>
    /// 
    /// </summary>
    private void CreateGraphicsGameObject()
    {
        if (agent.createGraphics)
        {
            var resource = "Ships/";
            resource += agent.species.ToString() + "/";
            resource += agent.ship.ToString() + "Graphics";

            graphicsGameObject = Instantiate(Resources.Load(resource)) as GameObject;
            graphicsGameObject.MakeChildOf(gameObject, "Graphics");
        }
        else
        {
            var renderer = gameObject.GetComponentInChildren(typeof(RendererManager));

            if (renderer != null)
            {
                graphicsGameObject = renderer.gameObject;
            }
            else
            {
                graphicsGameObject = new GameObject();
                graphicsGameObject.transform.parent = gameObject.transform;
                graphicsGameObject.transform.localPosition = Vector3.zero;
                graphicsGameObject.name = "Graphics";
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void ApplyTeamColors()
    {
        var teamColor = GameManager.instance.teamColors[agent.team];

        var rendererManager = graphicsGameObject.GetComponent<RendererManager>();
        rendererManager.SetTeamColor(teamColor);
    }

    /// <summary>
    /// Updates the <see cref="GameObject"/> that represent the graphics for this mover to face 
    /// to correct heading for the mover's current velocity.
    /// </summary>
    private void UpdateGraphicsHeading()
    {
        if (graphicsGameObject != null)
        {
            var targetDir = agent.mover.heading;

            var newDir = Vector3.RotateTowards(
                graphicsGameObject.transform.forward,
                targetDir,
                Time.fixedDeltaTime * 10, 0.0f);

            graphicsGameObject.transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}
