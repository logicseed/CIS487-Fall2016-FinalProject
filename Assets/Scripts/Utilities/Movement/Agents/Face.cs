// Marc King - mjking@umich.edu

using UnityEngine;

public class Face : Align
{
    protected GameObject targetAux;

    #region MonoBehavior Methods

    protected override void Awake ()
    { 
        base.Awake();
        targetAux = target;
        target = new GameObject();
        target.AddComponent<Agent>();
    }

    private void OnDestroy () 
    { 
        Destroy(target);
    }

    #endregion MonoBehaviour Methods

    public override Steering GetSteering()
    {
        Vector3 direction = targetAux.transform.position - transform.position;
        if (direction.magnitude > 0.0f)
        {
            float targetOrientation = Mathf.Atan2(direction.x, direction.z);
            targetOrientation *= Mathf.Rad2Deg;
            target.GetComponent<Agent>().orientation = targetOrientation;
        }
        return base.GetSteering();
    }
}
