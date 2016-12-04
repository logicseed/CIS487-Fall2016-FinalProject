// Marc King - mjking@umich.edu

using UnityEngine;

public class GraphicsManager : MonoBehaviour
{
    [HideInInspector]
    public AgentManager agent;
    [HideInInspector]
    public GameObject graphicsGO;

    private void Start()
    {
        
    }

    private bool hasSetup = false;
    public void Setup(AgentManager agent, GameObject graphicsGO = null)
    {
        // Single execution
        if (hasSetup) return;
        hasSetup = true;

        this.agent = agent;
        this.graphicsGO = graphicsGO;

        CreateGraphics();
        ApplyTeamColors();
    }

    private void FixedUpdate()
    {
        UpdateGraphicsHeading();
    }

    /// <summary>
    /// 
    /// </summary>
    private void CreateGraphics()
    {
        if (graphicsGO == null)
        {
            var resource = "Ships/";
            resource += agent.species.ToString() + "/";
            resource += agent.ship.ToString() + "Graphics";

            graphicsGO = Instantiate(Resources.Load(resource)) as GameObject;
        }
        else
        {
            graphicsGO = Instantiate(graphicsGO) as GameObject;
        }
        graphicsGO.MakeChildOf(gameObject, "Graphics");
    }

    /// <summary>
    /// 
    /// </summary>
    public void ApplyTeamColors()
    {
        var teamColor = GameManager.Instance.teamColors[agent.team];

        var rendererManager = graphicsGO.GetComponent<RendererManager>();
        rendererManager.SetTeamColor(teamColor);
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
