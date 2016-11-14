// Marc King - mjking@umich.edu

using UnityEngine;
using System.Collections;

[System.Serializable]
public class EvadeBehaviour : TargetBehaviour
{
    #region Inspector Fields
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
    : base (targetTransform, deleteWhenNull) { }

    #endregion Constructors
    #region Public Properties
    #endregion Public Properties


}
