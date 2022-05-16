using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int currentLevel = 0;

    public static bool grenadeLauncherEnabled = false;
    public static bool NFT1Enabled = false;
    public static bool NFT2Enabled = false;
    public static bool NFT3Enabled = false;

    public GameObject NFT1;

    public GameObject NFT2;

    public GameObject NFT3;

    private void Start()
    {
        scoreText.text = ScoreManager.availableCoins.ToString();
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        print("Current level: " + currentLevel);

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
        if (ScoreManager.score >= 200 && currentLevel == 0) {
            currentLevel++;
            SceneManager.LoadScene("Shop");
            //SwitchLevel(1);
        }
        if (ScoreManager.score >= 500 && currentLevel == 1) {
            currentLevel++;
            SceneManager.LoadScene("Shop");
            //SwitchLevel(1);
        }

        //if (ScoreManager.score >= 500 && currentLevel == 1) SwitchLevel(2);
        if (ScoreManager.score >= 1000 && currentLevel == 2) SwitchLevel(3);
    }

    public void SwitchLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void IncreaseScore(int amount)
    {
        ScoreManager.score += amount;
        ScoreManager.availableCoins += amount;
        Mathf.Clamp(ScoreManager.score, 0, 1000);
        UpdateScoreText(ScoreManager.availableCoins);
    }

    public void DecreaseScore(int amount)
    {
        ScoreManager.score -= amount;
        ScoreManager.availableCoins -= amount;
        Mathf.Clamp(ScoreManager.score, 0, 1000);
        Mathf.Clamp(ScoreManager.availableCoins, 0, 1000);
        UpdateScoreText(ScoreManager.availableCoins);
    }

    public void UpdateScoreText(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

}
