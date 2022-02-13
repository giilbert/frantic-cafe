using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : Interactable
{
    public override string GetTitle()
    {
        return "Trash Can";
    }

    public override string GetDescription()
    {
        Item itemInHand = PlayerInventory.Instance.currentHand;

        if (itemInHand == null) return "You can't throw air away.";

        return "Throw away " + itemInHand.GetName();
    }

    public override void Interact()
    {
        Item itemInHand = PlayerInventory.Instance.currentHand;

        if (itemInHand == null) return;

        PlayerInventory.Instance.ChangeHand(null);
        MoneyScore.Instance.IncreaseScore(-3f);
    }
}
