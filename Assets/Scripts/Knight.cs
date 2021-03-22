using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy , IInteractable
{
    public void Interact()
    {
        Debug.Log("Auf die Schnauze?!");
    }
}
