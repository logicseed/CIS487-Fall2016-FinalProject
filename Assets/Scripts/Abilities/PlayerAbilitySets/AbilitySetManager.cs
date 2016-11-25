using UnityEngine;

/// <summary>
/// TODO: Need cooldown manager
/// </summary>
public class AbilitySetManager : MonoBehaviour
{
    public PlayerAbilitySet playerAbility;

    // Use this for initialization
    void Start ()
    {
        playerAbility.ability1.initialize(gameObject);
        playerAbility.ability2.initialize(gameObject);
        playerAbility.ability3.initialize(gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyUp("z"))
        {
            playerAbility.ability1.cast();
        }
        else if (Input.GetKeyUp("x"))
        {
            playerAbility.ability2.cast();
        }
        else if (Input.GetKeyUp("c"))
        {
            playerAbility.ability3.cast();
        }
    }
}
