using UnityEngine;
using System.Collections.Generic;

public class AbilityComponent : MonoBehaviour
{
    /// <summary>
    /// All abilities components should have a radius to effect to allow for 
    /// area of effect. Make radius small in size if area of effect is not needed.
    /// </summary>
    public float radius;

    /// <summary>
    /// The potency of that effect
    /// </summary>
    public float magnitude;

    /// <summary>
    /// Used for team comparisons and who to apply effects to
    /// </summary>
    protected AgentManager agent;
    protected AgentManager objectAgent;
}
