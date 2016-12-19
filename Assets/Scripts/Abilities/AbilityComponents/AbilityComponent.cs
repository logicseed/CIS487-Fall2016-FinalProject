using UnityEngine;

/// <summary>
/// Basis for ability components.
/// </summary>
public class AbilityComponent : MonoBehaviour
{
    [Tooltip("The radius in which the ability effect will be applied")]
    public float radius;

    [Tooltip("The potency of the effect")]
    public float magnitude;

    // Used for team comparisons. Determines who will actually be effected by the ability.
    protected AgentManager agent;
    protected AgentManager objectAgent;

    //Triggers
    protected DestoryOnCollide collide;
}
