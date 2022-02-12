using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        Click,
        Hold
    }

    public InteractionType type;

    bool isHidden = true;
    public void HideOutline()
    {
        if (!isHidden)
        {
            // TODO: maybe?
        }
    }

    public void ShowOutline()
    {
        if (isHidden)
        {
            // TODO: maybe?
        }
    }

    void OnMouseExit()
    {
        HideOutline();
    }

    public abstract string GetTitle();
    public abstract string GetDescription();
    public abstract void Interact();
}
