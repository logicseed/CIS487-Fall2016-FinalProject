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
    public int damage = 10;

    #region MonoBehavior Methods
    private void Awake() { }
    private void Start()
    {
        agent = gameObject.GetComponent<AgentManager>();
        var go = Instantiate(Resources.Load("Weapon")) as GameObject;
        go.MakeChildOf(gameObject, "Weapon");
        lineRenderer = go.GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(GameManager.instance.GetTeamColor(agent.team), Color.white);
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
                if (isServer)
                {
                    StartCoroutine(FireAutoAttack());
                }
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

    [Server]
    public IEnumerator FireAutoAttack()
    {
        RpcShowAutoAttack();
        yield return new WaitForSeconds(0.5f);
        if (agent.target.direct.type == AgentType.CapturePlanet)
        {
            agent.target.direct.capture.ApplyInfluence(agent.team, damage);
        }
        else
        {
            agent.target.direct.ApplyDamage(damage);
        }
        RpcHideAutoAttack();
    }

    [ClientRpc]
    public void RpcShowAutoAttack()
    {
        //lineRenderer.SetPosition(1, position);
        lineRenderer.enabled = true;
    }

    [ClientRpc]
    public void RpcHideAutoAttack()
    {
        lineRenderer.enabled = false;
    }
}
