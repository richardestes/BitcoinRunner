using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    private void Start()
    {
        score = 0;
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        Mathf.Clamp(score, 0, 1000);
        scoreText.text = score.ToString();
    }

    public void DecreaseScore(int amount)
    {
        score -= amount;
        Mathf.Clamp(score, 0, 1000);
        scoreText.text = score.ToString();
    }
}
