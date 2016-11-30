// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class ObjectLifetime : MonoBehaviour
{
    public float lifetime = 0.5f;
    private float spawnTime;

    #region MonoBehavior Methods

    private void Start()
    {
        spawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time > spawnTime + lifetime) Destroy(gameObject);
    }

    #endregion MonoBehaviour Methods

}
