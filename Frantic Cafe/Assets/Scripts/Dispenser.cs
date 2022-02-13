using System.Collections;
using UnityEngine;

public class Dispenser : Interactable
{
    public enum Dispensees
    {
        PeanutJam,
        StrawberryJam
    }

    public Dispensees what;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override string GetTitle()
    {
        if (PlayerInventory.Instance.currentHand == null) return null;

        return GetDispensee() + " Dispenser";
    }

    public override string GetDescription()
    {
        Item itemInHand = PlayerInventory.Instance.currentHand;

        if (
            itemInHand.GetId() != Items.Toast &&
            itemInHand.GetId() != Items.ToastWithPeanutJam &&
            itemInHand.GetId() != Items.ToastWithStrawberryJam
        )
            return "You can't put " + GetDispensee() + " on " + itemInHand.GetName();

        return "Dispense " + GetDispensee() + " on " + itemInHand.GetName();
    }

    public override void Interact()
    {
        Item itemInHand = PlayerInventory.Instance.currentHand;

        switch (itemInHand.GetId())
        {
            case Items.Toast:
                ReplaceItemInHand(Items.Toast);
                break;
            case Items.ToastWithPeanutJam:
                ReplaceItemInHand(Items.ToastWithPeanutJam);
                break;
            case Items.ToastWithStrawberryJam:
                ReplaceItemInHand(Items.ToastWithStrawberryJam);
                break;
        }
    }

    // does the logic to replace the item based on what it dispenses
    void ReplaceItemInHand(Items itemType)
    {
        if (itemType == Items.Toast)
        {
            if (what == Dispensees.PeanutJam)
            {
                PlayerInventory.Instance.ChangeHand(new ToastWithPeanutJam(), true);
                return;
            }
            else if (what == Dispensees.StrawberryJam)
            {
                PlayerInventory.Instance.ChangeHand(new ToastWithStrawberryJam(), true);
                return;
            }
        }

        if (itemType == Items.ToastWithPeanutJam && what == Dispensees.StrawberryJam)
        {
            PlayerInventory.Instance.ChangeHand(new ToastWithPeanutAndStrawberryJam(), true);
        }
        if (itemType == Items.ToastWithStrawberryJam && what == Dispensees.PeanutJam)
        {
            PlayerInventory.Instance.ChangeHand(new ToastWithPeanutAndStrawberryJam(), true);
        }
    }

    string GetDispensee()
    {
        switch (what)
        {
            case Dispensees.PeanutJam:
                return "Peanut Jam";
            case Dispensees.StrawberryJam:
                return "Strawberry Jam";
        }

        return "Nothing";
    }
}
