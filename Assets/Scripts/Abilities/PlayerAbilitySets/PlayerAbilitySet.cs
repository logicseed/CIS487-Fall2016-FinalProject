using UnityEngine;
using System.Collections;

/// <summary>
/// Ability set scriptable object that will accept individual ability scriptalbe objects.
/// These objects are attached to the AbilitySetManager.
/// Create a new player ability set: Assets --> Create --> New Player ability set
/// </summary>
[CreateAssetMenu(menuName = "New Player ability set")]
[System.Serializable]
public class PlayerAbilitySet : ScriptableObject
{
    public Ability ability1;
    public Ability ability2;
    public Ability ability3;
}
