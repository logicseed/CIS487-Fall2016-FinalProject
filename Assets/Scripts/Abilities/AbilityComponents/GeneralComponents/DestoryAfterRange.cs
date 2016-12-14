using UnityEngine;

/// <summary>
/// Destroys an object after it has traveled a set amount of range.
/// </summary>
public class DestoryAfterRange : MonoBehaviour
{
    Vector3 startPosition;
    public float range;

    void Start ()
    {
        startPosition = transform.position;
	}
	
	void Update ()
    {
        if (Vector3.Distance(startPosition, gameObject.transform.position) >= range)
            Destroy(gameObject);
	}
}
