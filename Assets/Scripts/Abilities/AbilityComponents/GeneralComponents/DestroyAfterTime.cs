using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Destroy object after a set amount of time after being instantiated.
/// </summary>
public class DestroyAfterTime : NetworkBehaviour
{
    public float duration;
    float time;
    
    void Start()
    {
        time = Time.time;
    }

    void Update()
    {
        if (time + duration < Time.time)
            NetworkServer.Destroy(gameObject);
    }
}
