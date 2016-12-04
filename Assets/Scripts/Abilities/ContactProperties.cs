using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Ability/New Contact ability")]
public class ContactProperties : Ability
{
    private ContactBehavior contact;
    /// <summary>
    /// Give the information from the scriptable object to the monobehavior
    /// handlers. 
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(GameObject obj)
    {
        contact = obj.GetComponent<ContactBehavior>();
    }

    /// <summary>
    /// cast ability using monobehavior handlers. Used to cast generic
    /// abilities. More complicated things may not be able to be done here.
    /// </summary>
    public override void cast()
    {
        contact.cast();
    }
}
