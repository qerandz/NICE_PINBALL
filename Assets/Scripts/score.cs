using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public int bestScore;
    public int currentScore;
    [SerializeField] public Text scoreText;
    public static score instance { get; set; }
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        instance = this;
    }
    private void TryToSaveBestScore()
    {
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            // Сохранение лучшего счета
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void minusCurrentScore()
    {
        currentScore -= 10;
        scoreText.text = currentScore.ToString();
        TryToSaveBestScore();
    }
    public void PlusCurrentScore()
    {
        currentScore += 10;
        scoreText.text = currentScore.ToString();
        TryToSaveBestScore();
    }

    public void bigCurrentScore()
    {
        currentScore += 150;
        scoreText.text = currentScore.ToString();
        TryToSaveBestScore();
    }

}
