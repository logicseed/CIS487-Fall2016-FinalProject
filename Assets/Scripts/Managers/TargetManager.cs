// Marc King - mjking@umich.edu

using UnityEngine;

/// <summary>
/// Manages the targets of an agent.
/// </summary>
[RequireComponent(typeof(AgentManager))]
[DisallowMultipleComponent]
public class TargetManager : MonoBehaviour
{
    private AgentManager agent;
    private DirectTarget directTarget;
    private LocationTarget locationTarget;

    void Start()
    {
        agent = gameObject.GetComponent<AgentManager>();
    }

    void Update()
    {
        // If close to location target, remove the location target.
        if (locationTarget != null)
        {
            var distance = Vector3.Distance(agent.position, locationTarget.position);
            if (distance <= 0.5f) RemoveLocationTarget();
        }
    }

    /// <summary>
    /// Sets the location target to a Vector3 position.
    /// </summary>
    /// <returns>True if set; false otherwise.</returns>
    public bool SetLocationTarget(Vector3 position)
    {
        //Debug.Log("Setting a location target: " + position);
        if (HasLocationTarget()) RemoveLocationTarget();

        locationTarget = new LocationTarget(position);
        if (agent.isPlayer) CreateTargetGraphic(locationTarget);
        return HasLocationTarget();
    }

    /// <summary>
    /// Gets the location target.
    /// </summary>
    /// <returns>The location target.</returns>
    public LocationTarget GetLocationTarget()
    {
        return locationTarget;
    }

    /// <summary>
    /// The location target. Do not attempt to manually set properties.
    /// </summary>
    public LocationTarget location
    {
        get
        {
            return locationTarget;
        }
    }

    /// <summary>
    /// Determines if a location target is set.
    /// </summary>
    /// <returns>True if a location target is set; false otherwise.</returns>
    public bool HasLocationTarget()
    {
        return locationTarget != null;
    }

    /// <summary>
    /// Removes the location target.
    /// </summary>
    /// <returns>True if removed; false otherwise.</returns>
    public bool RemoveLocationTarget()
    {
        Destroy(locationTarget.graphicGameObject);
        locationTarget = null;
        return !HasLocationTarget();
    }

    /// <summary>
    /// Sets the direct target to a type and game object.
    /// </summary>
    /// <param name="type">The type of target.</param>
    /// <param name="target">The game object of the target.</param>
    /// <returns>True if set; false otherwise.</returns>
    public bool SetDirectTarget(TargetType type, GameObject target)
    {
        if (HasDirectTarget()) RemoveDirectTarget();

        directTarget = new DirectTarget(type, target);
        CreateTargetGraphic(directTarget);
        return HasDirectTarget();
    }

    /// <summary>
    /// Gets the direct target.
    /// </summary>
    /// <returns>The direct target.</returns>
    public DirectTarget GetDirectTarget()
    {
        return directTarget;
    }

    /// <summary>
    /// The direct target. Do not attempt to manually set properties.
    /// </summary>
    public DirectTarget direct
    {
        get
        {
            return directTarget;
        }
    }

    /// <summary>
    /// Determines if a direct target is set.
    /// </summary>
    /// <returns>True if a direct target is set; false otherwise.</returns>
    public bool HasDirectTarget()
    {
        return directTarget != null;
    }

    /// <summary>
    /// Removes the direct target.
    /// </summary>
    /// <returns>True if removed; false otherwise.</returns>
    public bool RemoveDirectTarget()
    {
        Destroy(directTarget.graphicGameObject);
        directTarget = null;
        return !HasDirectTarget();
    }

    /// <summary>
    /// Instantiates and parents the appropriate graphical indicator for the target type.
    /// </summary>
    /// <param name="target">The target for which to create the graphical indicator.</param>
    private void CreateTargetGraphic(Target target)
    {
        if (target.graphicGameObject != null) Destroy(target.graphicGameObject);

        GameObject graphic;

        switch (target.type)
        {
            case TargetType.Ally:
            case TargetType.AllyCapture:
                graphic = Instantiate(Resources.Load("TargetSelectionAlly")) as GameObject;
                break;

            case TargetType.Enemy:
            case TargetType.EnemyCapture:
                graphic = Instantiate(Resources.Load("TargetSelectionEnemy")) as GameObject;
                break;

            case TargetType.Location:
            default:
                graphic = Instantiate(Resources.Load("TargetSelectionLocation")) as GameObject;
                break;
        }

        var graphicGameObject = new GameObject("Target Indicator");
        graphicGameObject.transform.position = target.position;
        graphicGameObject.layer = LayerMask.NameToLayer(agent.teamLayer);

        graphic.transform.parent = graphicGameObject.transform;
        graphic.transform.localPosition = Vector3.zero;
        graphic.layer = LayerMask.NameToLayer(agent.teamLayer);

        if (target.type != TargetType.Location)
        {
            graphicGameObject.transform.parent = target.transform;
            graphicGameObject.transform.localPosition = Vector3.zero;
        }

        target.graphicGameObject = graphicGameObject;
    }
}
