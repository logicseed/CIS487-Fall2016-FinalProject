// Marc King - mjking@umich.edu

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[DisallowMultipleComponent]
public class AgentManager : NetworkBehaviour
{
    [Tooltip("The type determines which components will be attached to this agent.")]
    [SyncVar]
    public AgentType type = AgentType.None;
    [Tooltip("The team determines how other agents respond to this agent.")]
    [SyncVar]
    public TeamType team = TeamType.World;
    [HideInInspector]
    public bool isPlayer = false;
    [HideInInspector]
    public string teamLayer = "Default";

    [Header("Health & Shields")]
    [SerializeField]
    [Range(0, 100)]
    private int healRate = 0;
    [SyncVar]
    [Range(0, 5000)]
    public int maximumHealth = 100;
    [HideInInspector]
    [SyncVar]
    public int health;
    [SerializeField]
    [Range(0, 100)]
    private int rechargeRate = 0;
    [SyncVar]
    [Range(0, 5000)]
    public int maximumShields = 100;
    [HideInInspector]
    [SyncVar]
    public int shields;
    [HideInInspector]
    [SyncVar]
    public bool hasDied = false;
    

    [Header("Mover")]
    [Tooltip("The maximum speed the agent can attain.")]
    [SerializeField]
    [Range(0.0f, 20.0f)]
    private float maximumSpeed = 5.0f;
    [Tooltip("The maximum change in speed and direction the agent can perform.")]
    [SerializeField]
    [Range(0.0f, 5.0f)]
    private float maximumAcceleration = 0.5f;
    [SerializeField]
    [Range(1.0f, 5000.0f)]
    private float mass = 1.0f;
    [SerializeField]
    [Range(0.0f, 100.0f)]
    private float collisionRadius = 1.0f;
    [HideInInspector]
    public StandardMover mover;

    [Header("Graphics")]
    [SerializeField]
    private GameObject graphicsGO = null;
    [SyncVar]
    public SpeciesType species;
    [SyncVar]
    public ShipType ship;
    [HideInInspector]
    public GraphicsManager graphics;

    [Header("Target")]

    [HideInInspector]
    public TargetManager target;






    [HideInInspector]
    public GameManager game;
    [HideInInspector]
    public LevelManager level;

    [HideInInspector]
    public SphereCollider sphere;
    [HideInInspector]
    public new Rigidbody rigidbody;





    protected virtual void Awake()
    {
        health = maximumHealth;
        shields = maximumShields;
    }

    [ClientRpc]
    public void RpcRemoteSetup()
    {
        
    }


    private bool hasSetup = false;
    public void Setup(GameObject graphicsGO = null)
    {
        // Single execution
        if (hasSetup) return;
        hasSetup = true;

        // Setup components

        // Rigidbody
        if (type != AgentType.TargetIndicator)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
            rigidbody.useGravity = false;
            rigidbody.isKinematic = false;
            rigidbody.mass = mass;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        }

        // Network Transform
        if (type != AgentType.TargetIndicator && type != AgentType.DevPlayer)
        {
            var netTransform = gameObject.AddComponent<NetworkTransform>();
            netTransform.transformSyncMode = NetworkTransform.TransformSyncMode.SyncRigidbody3D;
        }

        // Sphere Collider
        if (type != AgentType.TargetIndicator)
        {
            sphere = gameObject.AddComponent<SphereCollider>();
            sphere.isTrigger = false;
            sphere.radius = collisionRadius;
        }

        // Standard Mover
        if (type != AgentType.TargetIndicator)
        {
            mover = gameObject.AddComponent<StandardMover>();
            mover.Setup(this, maximumSpeed, maximumAcceleration, rigidbody);
        }

        // Graphics Manager
        this.graphicsGO = graphicsGO;
        graphics = gameObject.AddComponent<GraphicsManager>();
        graphics.Setup(this, graphicsGO);

        // Target Manager
        if (type != AgentType.TargetIndicator)
        {
            target = gameObject.AddComponent<TargetManager>();
            target.Setup(this);
        }

    }

    protected virtual void Start()
    {
        if (type == AgentType.HomePlanet || type == AgentType.CapturePlanet || type == AgentType.DevPlayer)
        {
            Setup(graphicsGO);
        }
    }

    public override void OnStartLocalPlayer()
    {
        Setup(graphicsGO);
    }

    public void FixedUpdate()
    {
        if (isServer) HandleHealth();
    }

    [Server]
    protected virtual void HandleHealth()
    {
        if (health <= 0 && !hasDied) CmdKillerPlayer();

        health = Mathf.Clamp(health + Mathf.RoundToInt(healRate * Time.fixedDeltaTime), 0, maximumHealth);
        shields = Mathf.Clamp(shields + Mathf.RoundToInt(rechargeRate * Time.fixedDeltaTime), 0, maximumShields);
    }

    [Command]
    public void CmdKillerPlayer()
    {
        hasDied = true;
        StartCoroutine(SpawnExplosion());
    }

    public IEnumerator SpawnExplosion()
    {
        
        var explosion = Instantiate(Resources.Load("Explosion")) as GameObject;
        explosion.transform.parent = transform;
        explosion.transform.localPosition = Vector3.zero;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }



    /// <summary>
    /// The agent's position in space.
    /// </summary>
    public Vector3 position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    private void SetTeamLayer()
    {

    }
}
