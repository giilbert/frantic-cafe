using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    void Start()
    {
        TMP_Text text = GetComponent<TMP_Text>();

        text.text = "Earnings: $" + MoneyScore.currentScore.ToString("N2");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}
