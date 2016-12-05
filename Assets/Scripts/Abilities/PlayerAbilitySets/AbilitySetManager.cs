using UnityEngine;

/// <summary>
/// Manages the set of player abilities along with there cooldowns
/// </summary>
public class AbilitySetManager : MonoBehaviour
{
    public PlayerAbilitySet playerAbility;
    float abilitycooldown1, abilitycooldown2, abilitycooldown3;

    void Start ()
    {
        playerAbility.ability1.initialize(gameObject);
        playerAbility.ability2.initialize(gameObject);
        playerAbility.ability3.initialize(gameObject);
    }

    void Update ()
    {
        if (Input.GetKeyUp("z") && Time.time >= abilitycooldown1)
        {
            playerAbility.ability1.cast();
            abilitycooldown1 = Time.time + playerAbility.ability1.cooldown;
        }
        else if (Input.GetKeyUp("x") && Time.time >= abilitycooldown2)
        {
            playerAbility.ability2.cast();
            abilitycooldown2 = Time.time + playerAbility.ability2.cooldown;
        }
        else if (Input.GetKeyUp("c") && Time.time > abilitycooldown3)
        {
            playerAbility.ability3.cast();
            abilitycooldown3 = Time.time + playerAbility.ability3.cooldown;

        }
    }
}
