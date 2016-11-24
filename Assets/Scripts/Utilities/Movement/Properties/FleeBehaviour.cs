// Marc King - mjking@umich.edu

/// <summary>
/// Properties for a flee behaviour.
/// </summary>
public class FleeBehaviour : TargetBehaviour
{
    /// <summary>
    /// Distance from target at which the mover will be considered to have fled. Measured in Unity units.
    /// </summary>
    public float distance = 20.0f;

    /// <summary>
    /// Whether or not this behaviour will be deleted after fleeing farther than the distance.
    /// </summary>
    public bool deleteWhenOutOfRange = true;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="targetAgent">The Transform that will be the target of this movement behaviour.</param>
    /// <param name="deleteWhenNull">Whether or not this behaviour should be removed when the Transform becomes null.</param>
    public FleeBehaviour(AgentManager targetAgent, bool deleteWhenNull = true)
    : base(targetAgent, deleteWhenNull)
    {
        this.type = BehaviourType.Flee;
    }
}
