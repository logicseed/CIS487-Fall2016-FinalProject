// Marc King - mjking@umich.edu

using UnityEngine;


[System.Serializable]
public class PursueBehaviour : TargetBehaviour
{
    [Header("Pursue Properties")]
    [SerializeField]
    private float prediction = 10.0f;
    [SerializeField]
    private float distance = 2.0f;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="targetTransform">The Transform that will be the target of this movement behaviour.</param>
    /// <param name="deleteWhenNull">Whether or not this behaviour should be removed when the Transform becomes null.</param>
    public PursueBehaviour(Transform targetTransform, bool deleteWhenNull = true) 
    : base (targetTransform, deleteWhenNull) { type = BehaviourType.Pursue; }

    public float Prediction
    {
        get
        {
            return prediction;
        }

        set
        {
            prediction = value;
        }
    }

    public float Distance
    {
        get
        {
            return distance;
        }

        set
        {
            distance = value;
        }
    }
}
