using UnityEngine;

/// <summary>
/// Player ability manager, will contain scriptable objects attached to keys
/// TODO: Need cooldown manager
/// </summary>
public class PlayerAbilityManager : MonoBehaviour
{
    public AbstractAbility ability1;
    public AbstractAbility ability2;
    public AbstractAbility ability3;

	// Use this for initialization
	void Start ()
    {   
        ability1.initialize(gameObject);
        ability2.initialize(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp("q"))
        {
            ability1.cast();
        }
        else if (Input.GetKeyUp("w"))
        {
            ability2.cast();
        }
        else if (Input.GetKeyUp("e"))
        {
        }
    }
}
