using UnityEngine;
using cakeslice;

public abstract class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        Click,
        Hold
    }

    public InteractionType type;

    Outline outline;
    void Start()
    {
        outline = GetComponent<Outline>();
        outline.OnDisable();
    }

    bool isHidden = true;
    public void HideOutline()
    {
        if (!isHidden)
        {
            outline.OnDisable();
            isHidden = true;
        }
    }

    public void ShowOutline()
    {
        if (isHidden)
        {
            outline.OnEnable();
            isHidden = false;
        }
    }

    void OnMouseExit()
    {
        HideOutline();
    }

    public abstract string GetDescription();
    public abstract void Interact();
}
