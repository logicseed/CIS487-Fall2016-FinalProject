using UnityEngine;
using System.Collections;

[RequireComponent(typeof(StandardMover))]
public class TargetManager : MonoBehaviour 
{
	public TargetType targetType;
	public GameObject target;
	public GameObject targetGraphic;
	public StandardMover standardMover;

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
		if (this.target == null) this.targetType = TargetType.None;
	}

	public void ResetTarget()
	{
		Destroy(this.targetGraphic);
		if (this.targetType == TargetType.Position) Destroy(this.target);

		this.target = null;
		this.targetType = TargetType.None;
	}

	public void SetTarget (GameObject target, TargetType targetType)
	{
		this.target = target;
		this.targetType = targetType;

		LoadTargetGraphic();
	}

	public void SetTarget (Vector3 targetPosition)
	{
		this.target = new GameObject();
		this.target.transform.position = targetPosition;
		this.targetType = TargetType.Position;

		LoadTargetGraphic();
	}

	private void LoadTargetGraphic()
	{
		switch (this.targetType) {
		case TargetType.Ally:
			this.targetGraphic = Instantiate (Resources.Load ("TargetSelectionAlly")) as GameObject;
			break;
		case TargetType.Enemy:
			this.targetGraphic = Instantiate (Resources.Load ("TargetSelectionEnemy")) as GameObject;
			break;
		case TargetType.CapturePoint:
			this.targetGraphic = Instantiate (Resources.Load ("TargetSelectionCapture")) as GameObject;
			break;
		case TargetType.Position:
			this.targetGraphic = Instantiate (Resources.Load ("TargetSelectionPosition")) as GameObject;
			DestroyThisOnContact dtoc = targetGraphic.GetComponent<DestroyThisOnContact> ();
			dtoc.destroyer = this.gameObject;
			dtoc.targetManager = this;    	
			break;
		}
		this.targetGraphic.transform.parent = this.target.transform;
		this.targetGraphic.transform.localPosition = Vector3.zero;
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
