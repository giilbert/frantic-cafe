using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class Thing : Interactable
{
    InteractionType interactionType = InteractionType.Click;

    public override string GetDescription()
    {
        return "asdsadasd";
    }

    public override void Interact()
    {
        Debug.Log("Interact!");
    }
}
