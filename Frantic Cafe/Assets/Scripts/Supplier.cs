using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ItemType
{
    InstantToastMix
}

public class Supplier : Interactable
{
    [SerializeField]
    ItemType item;

    public override string GetTitle()
    {
        switch (item)
        {
            case ItemType.InstantToastMix:
                return "Instant Toast Mix Box";
            default:
                return "hmm?";
        }
    }

    public override string GetDescription()
    {
        switch (item)
        {
            case ItemType.InstantToastMix:
                return "Take 1x Instant Toast Mix";
            default:
                return "hmm?";
        }
    }

    public override void Interact()
    {
        switch (item)
        {
            case ItemType.InstantToastMix:
                PlayerInventory.Instance.ChangeHand(new InstantToastMix());
                break;
        }
    }
}
