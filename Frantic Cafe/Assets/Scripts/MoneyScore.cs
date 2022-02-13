using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyScore : MonoBehaviour
{
    TMP_Text text;
    public static MoneyScore Instance { get; private set; }

    public static float currentScore = 0f;

    public void IncreaseScore(float x)
    {
        currentScore += x;
        UpdateUI();
    }

    void UpdateUI()
    {
        text.text = "$" + currentScore.ToString("N2");
    }

    void Start()
    {
        text = GetComponent<TMP_Text>();
        UpdateUI();
    }

    // singleton things
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There can't be more than 1 moneyscore instance");
            return;
        }

        Instance = this;
    }
}
