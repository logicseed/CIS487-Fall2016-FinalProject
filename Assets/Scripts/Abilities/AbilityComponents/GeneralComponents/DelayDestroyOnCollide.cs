using UnityEngine;
using System.Collections;
public class DelayDestroyOnCollide : MonoBehaviour
{
    [HideInInspector]
    public bool triggered;

    public float radius;
    AgentManager agent;
    AgentManager objectAgent;

    void Start()
    {
        objectAgent = GetComponent<AgentManager>();
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        foreach (Collider hit in hitColliders)
        {
            agent = hit.gameObject.GetComponent<AgentManager>();
            if (agent.team != objectAgent.team)
            {
                Transform temp = gameObject.transform.FindChild("Graphics");
                temp.gameObject.SetActive(false);
                triggered = true;

                if (GetComponent<Damage>() != null)
                    gameObject.GetComponent<Damage>().enabled = false;

                Destroy(gameObject, 20);
            }
        }
    }
}  