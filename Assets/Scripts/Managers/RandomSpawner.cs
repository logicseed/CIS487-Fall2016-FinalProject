// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour
{
    public GameObject randomAgent;

    private float timeBetweenSpawns = 2.0f;
    private float lastSpawn = 0.0f;


    #region MonoBehavior Methods
    private void Awake () { }
    private void Start () {
        lastSpawn = Time.time - (timeBetweenSpawns * Random.value);
     }
    private void FixedUpdate () {
        if (Time.time > lastSpawn + timeBetweenSpawns)
        {
            var go = (GameObject)Instantiate(Resources.Load("RandomAgent"));
            go.transform.parent = gameObject.transform;
            go.transform.localPosition = Vector3.zero;
            lastSpawn = Time.time;
        }

     }
    private void Update () { }
    private void LateUpdate () { }
    private void OnDestroy () { }
    #endregion MonoBehaviour Methods

}
