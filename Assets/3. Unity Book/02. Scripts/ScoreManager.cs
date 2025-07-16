using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI bestScoreUI;

    private int currentScore;
    private int bestScore;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        bestScoreUI.text = "�ְ� ���� : " + bestScore;

    }

    public void SetScore(int value)
    {
        currentScore = value;

        currentScoreUI.text = "���� ���� : " + currentScore;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreUI.text = "�ְ� ���� : " + bestScore;

            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

    public int GetScore()
    {
        return currentScore;
    }
}
