using UnityEngine;
using System.Collections;

[RequireComponent(typeof(StandardMover))]
public class TargetManager : MonoBehaviour 
{
	private TargetType targetType;
	private GameObject target;
	private GameObject targetGraphic;
	private StandardMover standardMover;

	// Use this for initialization
	void Start ()
	{
		this.target = null;
		this.targetGraphic = null;
		this.targetType = TargetType.None;
		this.standardMover = gameObject.GetComponent<StandardMover>();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.target = null) this.targetType = TargetType.None;
	}

	public void ResetTarget()
	{
		if (this.targetType == TargetType.Position) Destroy(this.target);
		Destroy(this.targetGraphic);
		this.target = null;
		this.targetType = TargetType.None;
	}

	public void SetTarget (GameObject target, TargetType targetType, MovementBehaviour behaviour)
	{
		this.target = target;
		this.targetType = targetType;

		LoadTargetGraphic();

		this.standardMover.AddBehaviour(behaviour);
	}

	public void SetTarget (Vector3 targetPosition, MovementBehaviour behaviour)
	{
		this.target = new GameObject();
		this.target.transform.position = targetPosition;
		this.targetType = TargetType.Position;

		LoadTargetGraphic();
		
		this.standardMover.AddBehaviour(behaviour);
	}

	private void LoadTargetGraphic()
	{
		switch (this.targetType)
		{
			case TargetType.Ally:
			this.targetGraphic = Instantiate(Resources.Load("TargetSelectionAlly")) as GameObject;
			break;
			case TargetType.Enemy:
			this.targetGraphic = Instantiate(Resources.Load("TargetSelectionEnemy")) as GameObject;
			break;
			case TargetType.CapturePoint:
			this.targetGraphic = Instantiate(Resources.Load("TargetSelectionCapture")) as GameObject;
			break;
			case TargetType.Position:
			this.targetGraphic = Instantiate(Resources.Load("TargetSelectionPosition")) as GameObject;
			break;
		}
		this.targetGraphic.transform.parent = this.target.transform;
	}

	public GameObject GetTarget()
	{
		return this.target;
	}
}

public enum TargetType
{
	None,
	Position,
	Ally,
	Enemy,
	CapturePoint
}
