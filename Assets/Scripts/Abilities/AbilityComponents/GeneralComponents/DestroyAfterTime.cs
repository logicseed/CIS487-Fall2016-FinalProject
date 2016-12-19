using UnityEngine;

/// <summary>
/// Destroy object after a set amount of time after being instantiated.
/// </summary>
public class DestroyAfterTime : MonoBehaviour
{
    public float duration;

    void Start()
    {
        Destroy(gameObject, duration);
    }
}
