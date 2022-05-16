using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public static int availableCoins = 0;
    private GameManager gameManager;

    private void Start()
    {
        if (!gameManager) gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        availableCoins += amount;
        Mathf.Clamp(score, 0, 1000);
        Mathf.Clamp(availableCoins, 0, 1000);
        gameManager.UpdateScoreText(availableCoins);
    }

    public void DecreaseScore(int amount)
    {
        score -= amount;
        availableCoins -= amount;
        Mathf.Clamp(availableCoins, 0, 1000);
        gameManager.UpdateScoreText(availableCoins);
    }
}
