// Marc King - mjking@umich.edu

using UnityEngine;

[RequireComponent(typeof(StandardMover))]
[RequireComponent(typeof(TargetManager))]
[RequireComponent(typeof(GraphicsManager))]
[DisallowMultipleComponent]
public class AgentManager : MonoBehaviour
{
    [Header("Populated at Runtime")]
    public StandardMover mover;
    public TargetManager target;
    public GraphicsManager graphics;
    //public AbilityController abilities;

    public Color teamColor = new Color(1.0f,1.0f,1.0f,1.0f);

    [HideInInspector]
    public bool isPlayer = false;
    [HideInInspector]
    public string teamLayer = "Default";

    protected virtual void Start()
    {
        mover = gameObject.GetComponent<StandardMover>();
        target = gameObject.GetComponent<TargetManager>();
        graphics = gameObject.GetComponent<GraphicsManager>();
        //abilities = gameObject.GetComponent<AbilityController>();
    }

    /// <summary>
    /// The agent's position in space.
    /// </summary>
    public Vector3 position
    {
        get
        {
            return transform.position;
        }
    }
}
