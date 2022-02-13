using System.Collections;
using UnityEngine;

public class CoffeeMaker : Interactable
{
    public int brewTime = 5;

    Item item;
    int coffeeLeft = 0;
    // for displaying the cup
    public SpriteRenderer spriteRenderer;

    public override string GetTitle()
    {
        Item currentHand = PlayerInventory.Instance.currentHand;

        return "Coffeematic 3000";
    }

    public override string GetDescription()
    {
        Item currentHand = PlayerInventory.Instance.currentHand;

        if (coffeeLeft <= 0) return "Coffeematic needs coffee grounds";
        if (currentHand?.GetId() == Items.Glass && coffeeLeft > 0) return "Fill glass with coffee";
        if (currentHand?.GetId() == Items.CoffeeGrounds && coffeeLeft <= 0) return "Refill coffee grounds";
        if (currentHand == null && item?.GetId() == Items.GlassOfCoffee) return "Take glass of coffee";

        return "Covfefe! Cups left: " + coffeeLeft;
    }

    public override void Interact()
    {
        Item itemInHand = PlayerInventory.Instance.currentHand;

        // take the cup of coffee
        if (item?.GetId() == Items.GlassOfCoffee && itemInHand == null)
        {
            PlayerInventory.Instance.ChangeHand(item);
            SwitchItem(null);
            return;
        }

        // refill machine
        if (itemInHand?.GetId() == Items.CoffeeGrounds && coffeeLeft <= 0)
        {
            PlayerInventory.Instance.ChangeHand(null);
            coffeeLeft = 4;
            return;
        }

        // change the item on the coffee maker
        if (itemInHand?.GetId() == Items.Glass && item == null && coffeeLeft > 0)
        {
            item = itemInHand;

            SwitchItem(item);

            PlayerInventory.Instance.ChangeHand(null);

            StartCoroutine(MakeCoffee());
        }
    }

    IEnumerator MakeCoffee()
    {
        yield return new WaitForSeconds(brewTime);
        SwitchItem(new GlassOfCoffee());
        coffeeLeft -= 1;
    }

    void SwitchItem(Item switchTo)
    {
        item = switchTo;

        if (switchTo == null)
        {
            spriteRenderer.gameObject.transform.localScale = Vector3.zero;
            return;
        }
        spriteRenderer.gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 1);

        Sprite sprite = Resources.Load<Sprite>(switchTo.GetResourceName());
        spriteRenderer.sprite = sprite;
    }
}
