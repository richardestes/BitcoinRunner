using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int currentLevel;

    private void Start()
    {
        scoreText.text = ScoreManager.score.ToString();
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        print("Current level: " + currentLevel);
    }

    private void Update()
    {
        if (ScoreManager.score >= 200 && currentLevel == 0) SwitchLevel(1);
        if (ScoreManager.score >= 500 && currentLevel == 1) SwitchLevel(2);
        if (ScoreManager.score >= 1000 && currentLevel == 2) SwitchLevel(3);
    }

    public void SwitchLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void IncreaseScore(int amount)
    {
        ScoreManager.score += amount;
        Mathf.Clamp(ScoreManager.score, 0, 1000);
        UpdateScoreText(ScoreManager.score);
    }

    public void DecreaseScore(int amount)
    {
        ScoreManager.score -= amount;
        Mathf.Clamp(ScoreManager.score, 0, 1000);
        UpdateScoreText(ScoreManager.score);
    }

    public void UpdateScoreText(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

}
