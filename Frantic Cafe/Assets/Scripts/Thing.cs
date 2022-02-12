using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : Interactable
{

    public override string GetTitle()
    {
        return "title";
    }

    public override string GetDescription()
    {
        return "asdsadasd";
    }

    public override void Interact()
    {
        Debug.Log("Interact!");
    }
}
