using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimePointController : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public bool isGameActive;


    private int score;
    private int timerSeconds = 60;

    private void Start()
    {
        isGameActive = true;
        StartCoroutine(GameTimer());
    }

    IEnumerator GameTimer()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            timerSeconds -= 1;
            timerText.text = "Time: " + timerSeconds;
            if (timerSeconds <= 0)
            {
                isGameActive = false;
            }
        }

    }

    // Update score with value from target clicked
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
