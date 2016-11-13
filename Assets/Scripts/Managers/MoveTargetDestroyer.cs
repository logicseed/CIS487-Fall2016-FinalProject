// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

public class MoveTargetDestroyer : MonoBehaviour
{
    public Color color;
    private Material material;

    private void Start()
    {
        var renderer = gameObject.GetComponent<MeshRenderer>();
        material = renderer.material;
        material.color = color;
    }

    private void Update()
    {
        material.color = color;
    }

    private void OnTriggerEnter(Collider collider)
    {
        // if (collider.gameObject.layer == 8)
        // {
            //collider.transform.parent.gameObject.GetComponent<StandardMover>().FleeTargets.Remove(transform);
            //collider.gameObject.GetComponent<SpaceshipMover>().FleeTargets.Remove(transform);
            Destroy(gameObject);
        // }
    }
}
