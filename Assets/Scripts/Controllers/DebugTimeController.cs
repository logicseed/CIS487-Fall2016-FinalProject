// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class DebugTimeController : MonoBehaviour
{
    [Range(0.0f,5.0f)]
    public float rate = 1.0f;

    private void Update ()
    {
        Time.timeScale = rate;
    }
}
