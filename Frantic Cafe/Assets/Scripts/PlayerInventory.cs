using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    public Image itemDisplay;

    public Item currentHand;

    // changes the item in the player's hand
    public void ChangeHand(Item item, bool replace = false)
    {
        // empty hand
        if (item == null)
        {
            currentHand = null;
            itemDisplay.color = Color.clear;
            return;
        }

        if (currentHand != null && !replace)
        {
            ToastMessage.Instance.Display("Your hands are full!");
            return;
        }

        currentHand = item;

        // change ui
        itemDisplay.color = Color.white;
        Texture2D texture = Resources.Load<Texture2D>(item.GetResourceName());
        itemDisplay.canvasRenderer.SetTexture(texture);

        // change player item texture
    }

    // singleton things
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There can't be more than 1 inventory instance");
            return;
        }

        Instance = this;
    }
}
