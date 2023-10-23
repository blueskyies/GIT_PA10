using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager thisManager = null;
    [SerializeField] private Text Txt_Score = null;
    [SerializeField] private Text Txt_Message = null;
    private int Score = 0;
    private Coroutine scoreIncreaseCoroutine;

    void Start()
    {
        thisManager = this;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Return))
            StartGame();
    }

    private void StartGame()
    {
        Score = 0;
        Time.timeScale = 1;
        Txt_Message.text = "";
        Txt_Score.text = "SCORE : 0";

        if (scoreIncreaseCoroutine != null)
        {
            StopCoroutine(scoreIncreaseCoroutine);
        }
        scoreIncreaseCoroutine = StartCoroutine(IncreaseScoreOverTime());
    }

    private IEnumerator IncreaseScoreOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); 
            Score += 1;
            Txt_Score.text = "SCORE : " + Score;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Txt_Message.text = "GAME OVER! \nPRESS ENTER TO RESTART GAME.";
        Txt_Message.color = Color.red;

        if (scoreIncreaseCoroutine != null)
        {
            StopCoroutine(scoreIncreaseCoroutine);
        }
    }
}