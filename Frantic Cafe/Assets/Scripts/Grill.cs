using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : Interactable
{
    Item item;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override string GetTitle()
    {
        if (item == null && PlayerInventory.Instance.currentHand == null) return null;
        return "Grill";
    }

    public override string GetDescription()
    {
        Item itemInHand = PlayerInventory.Instance.currentHand;

        if (itemInHand == null && item != null) return "Pick up " + item.GetName();
        if (itemInHand != null && item == null) return "Grill " + itemInHand.GetName();
        if (itemInHand != null && item != null) return "This grill is occupied";

        return "";
    }

    public override void Interact()
    {
        Item itemInHand = PlayerInventory.Instance.currentHand;

        // change the item on the grill
        if (itemInHand != null && item == null)
        {
            item = itemInHand;

            SwitchItem(item);

            PlayerInventory.Instance.ChangeHand(null);
            StartCoroutine(GrillThings());
        }

        // pick up the item
        if (itemInHand == null && item != null)
        {
            PlayerInventory.Instance.ChangeHand(item);
            item = null;
            spriteRenderer.sprite = null;
            StopAllCoroutines();
        }
    }

    IEnumerator GrillThings()
    {
        yield return new WaitForSeconds(15);

        if (item == null) yield break;

        switch (item.GetId())
        {
            case Items.InstantToastMix:
                SwitchItem(new Toast());
                break;
            default:
                SwitchItem(new Charcoal());
                break;
        }

        yield return GrillThings();
    }

    void SwitchItem(Item switchTo)
    {
        item = switchTo;
        Sprite sprite = Resources.Load<Sprite>(switchTo.GetResourceName());
        spriteRenderer.sprite = sprite;
    }
}
