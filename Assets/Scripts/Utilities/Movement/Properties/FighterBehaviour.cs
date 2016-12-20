// Marc King - mjking@umich.edu

using UnityEngine;

public class FighterBehaviour : MovementBehaviour
{
    /// <summary>
    /// /// Distance from target at which mover will begin slowing down. Measured in Unity units.
    /// </summary>
    public float approachRadius = 3.0f;

    /// <summary>
    /// Whether or not this behaviour should be removed when the Transform becomes null.
    /// </summary>
    public bool deleteWhenNull = true;

    public GameObject target = null;

    public FighterBehaviour()
    {
        type = BehaviourType.Fighter;
    }

}
