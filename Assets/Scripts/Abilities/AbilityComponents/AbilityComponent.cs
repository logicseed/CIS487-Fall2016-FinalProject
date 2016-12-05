using UnityEngine;
using System.Collections.Generic;

public class AbilityComponent : MonoBehaviour
{
    // All abilities components should have a radius to effect to allow for 
    // area of effect. Make radius small in size if area of effect is not needed.
    public float radius;

    // The potency of that effect
    public float magnitude;

    // Used for team comparisons. Determines who will actually be effected by the ability.
    protected AgentManager agent;
    protected AgentManager objectAgent;
}
