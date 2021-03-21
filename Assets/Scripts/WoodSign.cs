using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSign : MonoBehaviour, IInteractable
{
    public string signText;

    BoxCollider2D signCollider;

    public void Interact()
    {
        Debug.Log(signText);
    }

    void Awake()
    {
        BoxCollider2D[] tmpCollider = GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D bc in tmpCollider)
        {
            if (bc.isTrigger)
            {
                signCollider = GetComponent<BoxCollider2D>();
            }
        }
    }

}
