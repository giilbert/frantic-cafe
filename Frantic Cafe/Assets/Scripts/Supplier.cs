using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplier : Interactable
{
    InteractionType interactionType = InteractionType.Click;

    public Item item;

    public override string GetTitle()
    {
        return "Instant Toast Mix Box";
    }

    public override string GetDescription()
    {
        return "Take 1x [Instant Toast Mix]";
    }

    public override void Interact()
    {
        Debug.Log("bread supplier");
    }
}
