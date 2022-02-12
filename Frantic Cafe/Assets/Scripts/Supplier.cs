using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplier : Interactable
{
    [SerializeField]
    Item item;

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
        PlayerInventory.Instance.ChangeHand(new InstantToastMix());
    }
}
