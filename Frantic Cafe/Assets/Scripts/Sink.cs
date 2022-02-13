using System.Collections;
using UnityEngine;

public class Sink : Interactable
{
    public override string GetTitle()
    {
        if (PlayerInventory.Instance.currentHand?.GetId() != Items.Glass) return null;

        return "Sink";
    }

    public override string GetDescription()
    {
        return "Fill glass with water";
    }

    public override void Interact()
    {
        if (PlayerInventory.Instance.currentHand?.GetId() == Items.Glass)
        {
            PlayerInventory.Instance.ChangeHand(new GlassOfWater(), true);
        }
    }
}
