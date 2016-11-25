// Marc King - mjking@umich.edu

/// <summary>
/// Causes an agent to avoid another agent.
/// </summary>
public class EvadeBehaviour : TargetBehaviour
{
    public float prediction = 10.0f;
    public float distance = 2.0f;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="targetTransform">The Transform that will be the target of this movement behaviour.</param>
    /// <param name="deleteWhenNull">Whether or not this behaviour should be removed when the Transform becomes null.</param>
    public EvadeBehaviour(AgentManager targetAgent, bool deleteWhenNull = true) 
    : base (targetAgent, deleteWhenNull)
    {
        this.type = BehaviourType.Evade;
    }

}
