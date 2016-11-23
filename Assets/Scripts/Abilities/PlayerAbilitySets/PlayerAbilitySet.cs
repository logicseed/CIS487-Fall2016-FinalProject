using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Ability/New Player ability set")]
[System.Serializable]
public class PlayerAbilitySet : ScriptableObject
{
    public Ability ability1;
    public Ability ability2;
    public Ability ability3;
}
