using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class DestroyThisOnContact : MonoBehaviour 
{
	public GameObject destroyer;
	public float radius;
	public TargetManager targetManager;

	void Start()
	{
		if (radius != 0)
		{ 
			SphereCollider sphereCollider = gameObject.GetComponent<SphereCollider>();
			sphereCollider.radius = this.radius;
		}
	}
	public void SetDestroyer(GameObject destroyer)
	{
		this.destroyer = destroyer;
	}

	public void SetRadius(float radius)
	{
		this.radius = radius;
	}

	private void OnTriggerEnter(Collider collider)
  {
		//if (collider.gameObject == destroyer) Destroy(gameObject);
		targetManager.ResetTarget();
  }
}
