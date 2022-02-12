using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastMessage : MonoBehaviour
{
    public static ToastMessage Instance { get; private set; }
    TMPro.TMP_Text toastText;

    void Start()
    {
        toastText = GetComponent<TMPro.TMP_Text>();
    }

    public void Display(string text)
    {
        toastText.text = text;
        StartCoroutine(Hide());
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(2);
        toastText.text = "";
    }

    // singleton things
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There can't be more than 1 toastmessage instance");
            return;
        }

        Instance = this;
    }
}
