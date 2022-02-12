using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;
    public Camera cam;
    public TMP_Text interactionText;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), -Vector3.forward);


        if (hit.collider != null)
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable == null)
            {
                interactionText.gameObject.SetActive(false);
                return;
            }

            interactable.ShowOutline();

            // hides the text
            interactionText.gameObject.transform.localScale = Vector3.one;

            interactionText.text = interactable.GetDescription();

            // test for distance
            if (Vector3.Distance(transform.position, hit.collider.transform.position) > interactionDistance) return;

            if (Input.GetMouseButtonDown(0)) HandleInteraction(interactable);
        }
        else
        {
            // shows the text
            interactionText.gameObject.transform.localScale = Vector3.zero;
        }
    }

    void HandleInteraction(Interactable interactable)
    {
        Debug.Log("Interactable!");
    }
}
