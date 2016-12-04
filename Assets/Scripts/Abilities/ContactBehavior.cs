using UnityEngine;
using System.Collections;

public class ContactBehavior : MonoBehaviour
{
    public GameObject abilityObject;
    AgentManager agent;
    SphereCollider collide;
    
    void Start()
    {
        agent = GetComponent<AgentManager>();
        collide = GetComponent<SphereCollider>();
    }

    public void cast ()
    {

    }
}
