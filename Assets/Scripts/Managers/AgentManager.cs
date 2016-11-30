// Marc King - mjking@umich.edu

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;



[DisallowMultipleComponent]
public class AgentManager : NetworkBehaviour
{
    [HideInInspector]
    public GameManager game;

    public AgentType type = AgentType.None;
    public TeamType team = TeamType.Team1;

    public int health = 2;

    [HideInInspector]
    public StandardMover mover;
    [HideInInspector]
    public TargetManager target;
    [HideInInspector]
    public GraphicsManager graphics;
    [HideInInspector]
    public SphereCollider sphere;

    //public AbilityController abilities;

    [Header("Graphics")]
    public bool createGraphics = false;
    public SpeciesType species;
    public ShipType ship;

    [HideInInspector]
    public bool isPlayer = false;
    [HideInInspector]
    public string teamLayer = "Default";

    private bool hasDied = false;

    protected virtual void Awake()
    {
        mover = gameObject.GetComponent<StandardMover>();
        if (mover == null) mover = gameObject.AddComponent<NullStandardMover>() as NullStandardMover;

        target = gameObject.GetComponent<TargetManager>();
        if (target == null) target = gameObject.AddComponent<NullTargetManager>() as NullTargetManager;

        graphics = gameObject.GetComponent<GraphicsManager>();
        if (graphics == null) graphics = gameObject.AddComponent<NullGraphicsManager>() as NullGraphicsManager;

        sphere = gameObject.GetComponent<SphereCollider>();

        game = GameManager.Instance;
        //if (sphere == null) sphere = gameObject.AddComponent<SphereCollider>() as SphereCollider;

        //abilities = gameObject.GetComponent<AbilityController>();
    }

    public void FixedUpdate()
    {
        if (health <= 0 && !hasDied) StartCoroutine(SpawnExplosion());
    }

    public IEnumerator SpawnExplosion()
    {
        hasDied = true;
        var explosion = Instantiate(Resources.Load("Explosion")) as GameObject;
        explosion.transform.position = position;
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
