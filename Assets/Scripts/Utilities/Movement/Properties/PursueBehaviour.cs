// Marc King - mjking@umich.edu

using UnityEngine;


[System.Serializable]
public class PursueBehaviour : TargetBehaviour
{

    public float prediction = 10.0f;
    public float distance = 2.0f;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="targetTransform">The Transform that will be the target of this movement behaviour.</param>
    /// <param name="deleteWhenNull">Whether or not this behaviour should be removed when the Transform becomes null.</param>
    public PursueBehaviour(AgentManager target, bool deleteWhenNull = true) 
    : base (target, deleteWhenNull) { this.type = BehaviourType.Pursue; }
}
