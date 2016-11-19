// Marc King - mjking@umich.edu

using UnityEngine;

[RequireComponent(typeof(StandardMover))]
[RequireComponent(typeof(TargetManager))]
[RequireComponent(typeof(GraphicsManager))]
public class AgentManager : MonoBehaviour
{
    [Header("Populated at Runtime")]
    public StandardMover mover;
    public TargetManager targets;
    public GraphicsManager graphics;
    //public AbilityController abilities;

    protected virtual void Start()
    {
        mover = gameObject.GetComponent<StandardMover>();
        targets = gameObject.GetComponent<TargetManager>();
        graphics = gameObject.GetComponent<GraphicsManager>();
        //abilities = gameObject.GetComponent<AbilityController>();
    }
}
