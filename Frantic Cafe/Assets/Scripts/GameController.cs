using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int minutesLeft = 5;
    int secondsLeft = 0;
    TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();

        StartCoroutine(Tick());
    }

    IEnumerator Tick()
    {
        yield return new WaitForSeconds(2);

        while (true)
        {
            yield return new WaitForSeconds(1);

            secondsLeft -= 1;
            if (secondsLeft < 0)
            {
                minutesLeft -= 1;
                secondsLeft = 59;
            }

            if (secondsLeft == 0 && minutesLeft == 0)
            {
                text.text = "Finished!";
                yield return new WaitForSeconds(3);
                SceneManager.LoadScene("End", LoadSceneMode.Single);
            }

            UpdateUI();
        }
    }

    void UpdateUI()
    {
        string seconds = secondsLeft.ToString();

        if (seconds.Length == 1)
        {
            seconds = "0" + seconds;
        }

        text.text = minutesLeft + ":" + seconds;
    }
}
