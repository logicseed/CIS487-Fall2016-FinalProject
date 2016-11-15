// Marc King - mjking@umich.edu

using UnityEngine;

public class Pursue : Seek
{
    public float maxPrediction;
    private GameObject targetAux;
    private Agent targetAgent;

    #region MonoBehavior Methods

    protected override void Awake()
    {
        base.Awake();
        targetAgent = target.GetComponent<Agent>();
        targetAux = target;
        target = new GameObject();
    }

    private void OnDestroy()
    {
        Destroy(targetAux);
    }

    #endregion MonoBehaviour Methods

    public override Steering GetSteering()
    {
        Vector3 direction = targetAux.transform.position - transform.position;
        float distance = direction.magnitude;
        float speed = agent.velocity.magnitude;
        float prediction;
        if (speed <= distance / maxPrediction) prediction = maxPrediction;
        else prediction = distance / speed;
        target.transform.position = targetAux.transform.position;
        target.transform.position += targetAgent.velocity * prediction;
        return base.GetSteering();
    }
}
