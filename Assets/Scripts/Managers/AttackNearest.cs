// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class AttackNearest : MonoBehaviour
{
    private AgentManager agent;
    public float attackRange = 10.0f;
    public float timeBetweenTargeting = 5.0f;
    public float lastTargeting = 0.0f;

    #region MonoBehavior Methods
    private void Awake () { }
    private void Start () {
        agent = gameObject.GetComponent<AgentManager>();
     }
    private void FixedUpdate () {
        if (Time.time > lastTargeting + timeBetweenTargeting)
        {
            TargetNearest();
        }
     }
    private void Update () { }
    private void LateUpdate () {
        
     }
    private void OnDestroy () { }
    #endregion MonoBehaviour Methods

    public void TargetNearest()
    {
		var nearbyColliders = Physics.OverlapSphere(agent.position, attackRange);

		foreach(SphereCollider shipCollider in nearbyColliders)
        {
			var agentCollider = shipCollider.gameObject.GetComponent<AgentManager>();
            if (agentCollider.team != agent.team && agentCollider.type != AgentType.HomePlanet)
            {
                agent.target.CmdSetDirectTarget(agentCollider.gameObject);
                break;
            }
            continue;
		}
    }
}
