using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ItemType
{
    InstantToastMix,
    Glass,
    CoffeeGrounds
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
            case ItemType.Glass:
                return "Glass";
            case ItemType.CoffeeGrounds:
                return "Coffe Grounds";
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
            case ItemType.Glass:
                return "Take 1x Glass";
            case ItemType.CoffeeGrounds:
                return "Take 1x Coffee Grounds";
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
            case ItemType.Glass:
                PlayerInventory.Instance.ChangeHand(new Glass());
                break;
            case ItemType.CoffeeGrounds:
                PlayerInventory.Instance.ChangeHand(new CoffeeGrounds());
                break;
        }
    }
}
