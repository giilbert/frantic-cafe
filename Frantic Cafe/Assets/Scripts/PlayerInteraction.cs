using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;
    public Camera cam;
    public TMP_Text interactionTitle;
    public TMP_Text interactionDescription;
    public RectTransform interactionUI;

    AudioSource blipSound;

    void Start()
    {
        blipSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), -Vector3.forward);


        if (hit.collider != null)
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable == null)
            {
                interactionUI.localScale = Vector3.zero;
                return;
            }


            // test for distance
            if (Vector3.Distance(transform.position, hit.collider.transform.position) > interactionDistance) return;

            // interactable.ShowOutline();

            // hides the text
            string title = interactable.GetTitle();

            if (title == null)
            {
                interactionUI.localScale = Vector3.zero;
                return;
            }

            interactionUI.localScale = Vector3.one;
            interactionTitle.text = title;
            interactionDescription.text = interactable.GetDescription();

            if (Input.GetMouseButtonDown(0)) HandleInteraction(interactable);
        }
        else
        {
            // shows the text
            interactionUI.localScale = Vector3.zero;
        }
    }

    void HandleInteraction(Interactable interactable)
    {
        interactable.Interact();
        blipSound.Play();
    }
}
