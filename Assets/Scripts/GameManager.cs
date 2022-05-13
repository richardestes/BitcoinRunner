using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = ScoreManager.score.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) SwitchLevel();

    }

    // TODO: Fix this
    public void SwitchLevel()
    {
        SceneManager.LoadScene("Level2");
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
