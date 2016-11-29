// Marc King - mjking@umich.edu

using UnityEngine;

public class GraphicsManager : MonoBehaviour
{
    private AgentManager agent;
    private GameObject graphicsGameObject;

    public void Start()
    {
        agent = gameObject.GetComponent<AgentManager>();

        if (agent.createGraphics)
        {
            CreateGraphicsGameObject();
        }
        else
        {
            graphicsGameObject = gameObject.GetComponentInChildren(typeof(RendererManager)).gameObject;
        }
        
        ApplyTeamColors();
    }

    public void FixedUpdate()
    {
        UpdateGraphicsHeading();
    }

    private void CreateGraphicsGameObject()
    {
        var resource = "Ships/";
        resource += agent.species.ToString() + "/";
        resource += agent.ship.ToString() + "Graphics";

        graphicsGameObject = Instantiate(Resources.Load(resource)) as GameObject;
        graphicsGameObject.transform.parent = gameObject.transform;
        graphicsGameObject.transform.localPosition = Vector3.zero;
        graphicsGameObject.name = "Graphics";
    }

    private void ApplyTeamColors()
    {
        var rendererManager = graphicsGameObject.GetComponent<RendererManager>();
        rendererManager.SetTeamColors(agent.paintColor, agent.lightsColor);
    }

    /// <summary>
    /// Updates the <see cref="GameObject"/> that represent the graphics for this mover to face to correct heading for
    /// the mover's current velocity.
    /// </summary>
    private void UpdateGraphicsHeading()
    {
        if (graphicsGameObject != null)
        {
            var targetDir = agent.mover.heading;
            var newDir = Vector3.RotateTowards(graphicsGameObject.transform.forward, targetDir, Time.fixedDeltaTime * 10, 0.0f);
            graphicsGameObject.transform.rotation = Quaternion.LookRotation(newDir);
        }
    }

}
