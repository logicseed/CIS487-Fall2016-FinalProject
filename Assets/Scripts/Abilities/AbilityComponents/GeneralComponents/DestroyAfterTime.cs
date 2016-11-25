using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour
{
    float instantiationTime;
    public float duration;

    void Start()
    {
        instantiationTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - instantiationTime) >= duration)
            Destroy(gameObject);
    }
}
