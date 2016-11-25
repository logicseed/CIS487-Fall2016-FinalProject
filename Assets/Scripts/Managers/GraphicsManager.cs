// Marc King - mjking@umich.edu

using UnityEngine;

public class GraphicsManager : MonoBehaviour
{
    private AgentManager agent;

    /// <summary>
    /// <see cref="GameObject"/> reference to the graphical representation of this mover.
    /// </summary>
    [Tooltip("GameObject reference to the graphical representation of this mover.")]
    public GameObject graphics;
    public GameObject graphicsGameObject;

    public void Start()
    {
        agent = gameObject.GetComponent<AgentManager>();
    }

    public void FixedUpdate()
    {
        UpdateGraphicsHeading();
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
