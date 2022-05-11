using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    private GameManager gameManager;

    private void Start()
    {
        if (!gameManager) gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        Mathf.Clamp(score, 0, 1000);
        gameManager.UpdateScoreText(score);
    }

    public void DecreaseScore(int amount)
    {
        score -= amount;
        Mathf.Clamp(score, 0, 1000);
        gameManager.UpdateScoreText(score);
    }
}
