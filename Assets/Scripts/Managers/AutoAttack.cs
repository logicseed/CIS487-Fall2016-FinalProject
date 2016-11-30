// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class AutoAttack : NetworkBehaviour
{
    private AgentManager agent;
    private LineRenderer lineRenderer;

    public float timeBetweenAttacks = 1.0f;
    private float lastAttack = 0.0f;
    public float range = 10.0f;

    #region MonoBehavior Methods
    private void Awake() { }
    private void Start()
    {
        agent = gameObject.GetComponent<AgentManager>();
        var go = Instantiate(Resources.Load("Weapon")) as GameObject;
        go.MakeChildOf(gameObject, "Weapon");
        lineRenderer = go.GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(GameManager.instance.teamColors[agent.team], Color.white);
        lineRenderer.enabled = false;
    }
    private void FixedUpdate()
    {
        if (Time.time > lastAttack + timeBetweenAttacks)
        {
            //Debug.Log("Past time conditional");
            if (agent.target.direct != null && Vector3.Distance(agent.position, agent.target.direct.position) <= range)
            {
                //Debug.Log("Past target conditional");
                StartCoroutine(FireAutoAttack());
            }
            lastAttack = Time.time;
        }

        lineRenderer.SetPosition(0, agent.position);
        if (agent.target.direct != null) lineRenderer.SetPosition(1, agent.target.direct.position);
        else lineRenderer.SetPosition(1, agent.position);
    }
    private void Update() { }
    private void LateUpdate() { }
    private void OnDestroy() { }
    #endregion MonoBehaviour Methods

    public IEnumerator FireAutoAttack()
    {
        // draw beam
        //Debug.Log("Firing");
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.5f);

        lineRenderer.enabled = false;
        // reduce health
        agent.target.direct.currentHealth--;

    }
}
