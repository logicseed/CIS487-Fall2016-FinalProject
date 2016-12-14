using UnityEngine;

/// <summary>
/// Destroy object after a set amount of time after being instantiated.
/// </summary>
public class DestroyAfterTime : MonoBehaviour
{
    float instantiationTime;
    public float duration;

    void Start()
    {
        instantiationTime = Time.time;
    }

    void Update()
    {
        if ((Time.time - instantiationTime) >= duration)
            Destroy(gameObject);
    }
}
