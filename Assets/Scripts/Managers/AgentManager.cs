// Marc King - mjking@umich.edu

using UnityEngine;
using UnityEngine.Networking;

[DisallowMultipleComponent]
public class AgentManager : NetworkBehaviour
{
    public AgentType type = AgentType.None;
    [HideInInspector]
    public StandardMover mover;
    [HideInInspector]
    public TargetManager target;
    [HideInInspector]
    public GraphicsManager graphics;
    [HideInInspector]
    public SphereCollider sphere;

    //public AbilityController abilities;

    public Color teamColor = new Color(1.0f,1.0f,1.0f,1.0f);

    [HideInInspector]
    public bool isPlayer = false;
    [HideInInspector]
    public string teamLayer = "Default";

    protected virtual void Start()
    {
        mover = gameObject.GetComponent<StandardMover>();
        if (mover == null) mover = gameObject.AddComponent<NullStandardMover>() as NullStandardMover;

        target = gameObject.GetComponent<TargetManager>();
        if (target == null) target = gameObject.AddComponent<NullTargetManager>() as NullTargetManager;

        graphics = gameObject.GetComponent<GraphicsManager>();
        if (graphics == null) graphics = gameObject.AddComponent<NullGraphicsManager>() as NullGraphicsManager;

        sphere = gameObject.GetComponent<SphereCollider>();
        //if (sphere == null) sphere = gameObject.AddComponent<SphereCollider>() as SphereCollider;

        //abilities = gameObject.GetComponent<AbilityController>();
    }

    /// <summary>
    /// The agent's position in space.
    /// </summary>
    public Vector3 position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    
}
