using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public static bool grenadeLauncherEnabled = false;

    public static bool NFT1Enabled = false;

    public static bool NFT2Enabled = false;

    public static bool NFT3Enabled = false;

    public GameObject NFT1;

    public GameObject NFT2;

    public GameObject NFT3;

    private void Start()
    {
        scoreText.text = ScoreManager.score.ToString();
        if(NFT1Enabled) {
            NFT1.SetActive(true);
        }
        if(NFT2Enabled) {
            NFT2.SetActive(true);
        }
        if(NFT3Enabled) {
            NFT3.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) SwitchLevel();

        if(SceneManager.GetActiveScene().name == "Level1" && ScoreManager.score >= 200) {
            SwitchToShopLevel();
        }

    }

    public void SwitchToShopLevel() {
        SceneManager.LoadScene("Shop");
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
