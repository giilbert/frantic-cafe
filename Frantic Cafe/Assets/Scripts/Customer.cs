using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Customer : Interactable
{
    public
    static string[] names = {
        "Jessie",
        "Marion",
        "Jackie",
        "Alva",
        "Ollie",
        "Jodie",
        "Cleo",
        "Kerry",
        "Frankie",
        "Guadalupe",
        "Carey",
        "Tommie",
        "Angel",
        "Hollis",
        "Sammie",
        "Jamie",
        "Kris",
        "Robbie",
        "Tracy",
        "Merrill",
        "Noel",
        "Rene",
        "Johnnie",
        "Ariel",
        "Jan",
        "Casey",
        "Jackie",
        "Kerry",
        "Jodie",
        "Finley",
        "Skylar",
        "Justice",
        "Rene",
        "Darian",
        "Frankie",
        "Oakley",
        "Robbie",
        "Remy",
        "Milan",
        "Jaylin",
        "Devan",
        "Armani",
        "Charlie",
        "Stevie",
        "Channing",
        "Gerry",
        "Monroe",
        "Kirby",
        "Azariah",
        "Santana"
    };
    static Item[] possibleOrders = {
        new Toast(),
        new ToastWithPeanutJam(),
        new ToastWithStrawberryJam(),
        new ToastWithPeanutAndStrawberryJam(),
        new GlassOfWater()
    };
    int numOfCustomerSkins = 5;

    string customerName;
    Item currentOrder;
    // in seconds
    float timeLeft = 60;

    public float patience = 60;
    public int eatingCooldown = 30;
    public Transform bubble;
    public SpriteRenderer thoughtSpriteRenderer;
    public Image timer;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        timeLeft = patience;
        spriteRenderer = GetComponent<SpriteRenderer>();

        customerName = GetRandomName();
        currentOrder = GetRandomOrder();
        ChangeSkin();
        UpdateUIBubble();

        StartCoroutine(TickDown());
    }

    string GetRandomName()
    {
        int idx = Random.Range(0, names.Length);
        return names[idx];
    }

    Item GetRandomOrder()
    {
        int idx = Random.Range(0, possibleOrders.Length);
        return possibleOrders[idx];
    }

    void ChangeSkin()
    {
        int idx = Random.Range(1, numOfCustomerSkins);
        Sprite newSprite = Resources.Load<Sprite>("People/" + idx.ToString());
        spriteRenderer.sprite = newSprite;
    }

    public override string GetTitle()
    {
        return customerName;
    }

    public override string GetDescription()
    {
        Item handItem = PlayerInventory.Instance.currentHand;
        if (handItem == null && currentOrder != null) return customerName + " wants a " + currentOrder.GetName();
        if (currentOrder == null) return customerName + " is eating";

        return "Give " + handItem.GetName() + " to " + customerName;
    }

    public override void Interact()
    {
        Item handItem = PlayerInventory.Instance.currentHand;

        if (handItem == null) return;
        if (currentOrder == null) return;

        if (handItem.GetId() == currentOrder.GetId())
        {
            ToastMessage.Instance.Display(customerName + ": Thank you!");
            GiveMoney();
            PlayerInventory.Instance.ChangeHand(null);

            currentOrder = null;
            UpdateUIBubble();
            StartCoroutine(GenerateNewOrder());
        }
        else
        {
            ToastMessage.Instance.Display(customerName + ": This isn't my order!");
        }
    }

    void UpdateUIBubble()
    {
        if (currentOrder == null)
        {
            bubble.transform.localScale = Vector3.zero;
            return;
        }
        else
        {
            bubble.transform.localScale = Vector3.one;
        }

        Sprite sprite = Resources.Load<Sprite>(currentOrder.GetResourceName());
        thoughtSpriteRenderer.sprite = sprite;
    }

    IEnumerator GenerateNewOrder()
    {
        yield return new WaitForSeconds(eatingCooldown);

        bool finished = Random.Range(0, 3) == 2;
        if (finished)
        {
            // get a new customer, and generate a new order
            spriteRenderer.sprite = null;
            customerName = null;
            yield return new WaitForSeconds(5);

            // basically refresh everything
            currentOrder = GetRandomOrder();
            customerName = GetRandomName();
            timeLeft = patience;
            ChangeSkin();
            UpdateUIBubble();
            UpdateTimer();
            StartCoroutine(TickDown());

            yield break;
        }

        currentOrder = GetRandomOrder();
        timeLeft = patience;
        UpdateUIBubble();
    }

    IEnumerator TickDown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft -= 1;
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        timer.fillAmount = timeLeft / patience;
    }

    void GiveMoney()
    {
        float timeTip = Mathf.Min(timeLeft - 60, 0) / 100f;
        float randomTip = Random.value * 4;
        float price = 4.0f;

        MoneyScore.Instance.IncreaseScore(timeTip + randomTip + price);
    }
}

