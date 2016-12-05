using UnityEngine;
using System.Collections;

/// <summary>
/// Properties for contact ability behavior
/// Create a new unity ability asset: Assets --> Create --> Ability --> New contact ability
/// </summary>
[CreateAssetMenu(menuName = "Ability/New Contact ability")]
public class ContactProperties : Ability
{
    ContactBehavior contact;
    public GameObject abilityObject;

    /// <summary>
    /// Give the information from the scriptable object to the monobehavior handler. 
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(GameObject obj)
    {
        contact = obj.GetComponent<ContactBehavior>();
        contact.abilityObject = abilityObject;
    }

    /// <summary>
    /// Cast ability using monobehavior handler. 
    /// </summary>
    public override void cast()
    {
        contact.cast();
    }
}
