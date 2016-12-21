// Marc King - mjking@umich.edu

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

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
    public float maximumHealth = 100.0f;
    [HideInInspector]
    [SyncVar]
    public float health;
    [SerializeField]
    [Range(0, 100)]
    private int rechargeRate = 0;
    [SyncVar]
    [Range(0, 5000)]
    public float maximumShields = 100;
    [HideInInspector]
    [SyncVar]
    public float shields;
    [HideInInspector]
    [SyncVar]
    public bool hasDied = false;
    

    [Header("Mover")]
    [Tooltip("The maximum speed the agent can attain.")]
    [SerializeField]
    [Range(0.0f, 200.0f)]
    private float maximumSpeed = 5.0f;
    [Tooltip("The maximum change in speed and direction the agent can perform.")]
    [SerializeField]
    [Range(0.0f, 50.0f)]
    private float maximumAcceleration = 0.5f;
    [SerializeField]
    [Range(1.0f, 5000.0f)]
    private float mass = 1.0f;
    // [SerializeField]
    // [Range(0.0f, 100.0f)]
    // private float collisionRadius = 1.0f;
    [HideInInspector]
    public StandardMover mover;

    [Header("Graphics")]
    // [SerializeField]
    // private GameObject graphicsGO = null;
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
    [HideInInspector]
    public CaptureManager capture;

    



    protected virtual void Awake()
    {
        health = maximumHealth;
        shields = maximumShields;
    }

    private bool hasStarted = false;
    public virtual void Start()
    {
        if (hasStarted) return;
        hasStarted = true;
        // Setup components

        // Rigidbody
        if (type != AgentType.TargetIndicator)
        {
            rigidbody = gameObject.GetComponent<Rigidbody>();
            rigidbody.useGravity = false;
            rigidbody.isKinematic = false;
            rigidbody.mass = mass;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        }

        // Network Transform
        if (type != AgentType.TargetIndicator)
        {
            var netTransform = gameObject.GetComponent<NetworkTransform>();
            netTransform.transformSyncMode = NetworkTransform.TransformSyncMode.SyncRigidbody3D;
        }

        // Sphere Collider
        if (type != AgentType.TargetIndicator)
        {
            sphere = gameObject.GetComponent<SphereCollider>();
            sphere.isTrigger = false;
        }

        // Standard Mover
        if (type != AgentType.TargetIndicator && type != AgentType.HomePlanet && type != AgentType.SpaceStation && type != AgentType.CapturePlanet)
        {
            mover = gameObject.GetComponent<StandardMover>();
            mover.Setup(this, maximumSpeed, maximumAcceleration, rigidbody);
        }

        // Graphics Manager
        graphics = gameObject.GetComponent<GraphicsManager>();
        if (type != AgentType.TargetIndicator) graphics.Setup(this);

        // Target Manager
        if (type != AgentType.TargetIndicator && type != AgentType.HomePlanet && type != AgentType.SpaceStation && type != AgentType.CapturePlanet)
        {
            target = gameObject.GetComponent<TargetManager>();
            target.Setup(this);
        }

        if (type == AgentType.Player || type == AgentType.Cruiser || type == AgentType.Fighter)
        {
            var go = Instantiate(Resources.Load("UnitPlaque"), Vector3.zero, Quaternion.Inverse(Quaternion.identity), gameObject.transform) as GameObject;
            go.transform.localPosition = new Vector3(0.0f, 2.0f, 0.0f);
        }

        if (type == AgentType.CapturePlanet)
        {
            capture = gameObject.GetComponent<CaptureManager>();
        }
    }

    public void FixedUpdate()
    {
        if (isServer) HandleHealth();
    }

    [Server]
    protected virtual void HandleHealth()
    {
        if (health <= 0.0f && !hasDied) CmdKillerPlayer();

        health = Mathf.Clamp(health + Mathf.RoundToInt(healRate * Time.fixedDeltaTime), 0, maximumHealth);
        shields = Mathf.Clamp(shields + Mathf.RoundToInt(rechargeRate * Time.fixedDeltaTime), 0, maximumShields);
    }

    [Server]
    public void ApplyDamage(float damage)
    {
        var unappliedDamage = damage;

        if (unappliedDamage <= 0.0f) return;

        if (shields > 0)
        {
            if (shields >= unappliedDamage)
            {
                shields -= unappliedDamage;
                unappliedDamage = 0.0f;
            }
            else
            {
                unappliedDamage -= shields;
                shields = 0.0f;
            }
        }

        if (unappliedDamage <= 0) return;

        health -= unappliedDamage;
    }

    [Command]
    public void CmdKillerPlayer()
    {
        hasDied = true;
        StartCoroutine(SpawnExplosion());
        SceneManager.LoadScene("Scoreboard");
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
}
