// Marc King - mjking@umich.edu

using UnityEngine;


[System.Serializable]
public class EvadeBehaviour : TargetBehaviour
{
    #region Inspector Fields
    [Header("Pursue Properties")]
    [SerializeField]
    private float prediction = 10.0f;
    [SerializeField]
    private float distance = 2.0f;
    #endregion Inspector Fields
    #region Private Fields
    #endregion Private Fields
    #region Constructors

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="targetTransform">The Transform that will be the target of this movement behaviour.</param>
    /// <param name="deleteWhenNull">Whether or not this behaviour should be removed when the Transform becomes null.</param>
    public EvadeBehaviour(Transform targetTransform, bool deleteWhenNull = true) 
    : base (targetTransform, deleteWhenNull) { type = BehaviourType.Evade; }

    #endregion Constructors
    #region Public Properties
    #endregion Public Properties

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
