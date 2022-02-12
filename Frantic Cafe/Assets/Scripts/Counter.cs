using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : Interactable
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
        return "Counter";
    }

    public override string GetDescription()
    {
        Item itemInHand = PlayerInventory.Instance.currentHand;

        if (itemInHand == null && item != null) return "Pick up " + item.GetName();
        if (itemInHand != null && item == null) return "Put " + itemInHand.GetName() + " on counter";
        if (itemInHand != null && item != null) return "This counter is occupied";

        return "";
    }

    public override void Interact()
    {
        Item itemInHand = PlayerInventory.Instance.currentHand;

        // change the item on the counter
        if (itemInHand != null && item == null)
        {
            item = itemInHand;

            Sprite sprite = Resources.Load<Sprite>(item.GetResourceName());
            spriteRenderer.sprite = sprite;

            PlayerInventory.Instance.ChangeHand(null);
        }

        // pick up the item
        if (itemInHand == null && item != null)
        {
            PlayerInventory.Instance.ChangeHand(item);
            item = null;
            spriteRenderer.sprite = null;
        }
    }
}
