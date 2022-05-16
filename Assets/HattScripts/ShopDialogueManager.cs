using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class ShopDialogueManager : MonoBehaviour
{

    public TextMeshProUGUI bitcoinCounter;

    public GameObject TextWindow;

    public string[] worldContextItems;


    // Start is called before the first frame update
    void Start()
    {
        //if (!gameManager) gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //if (!scoreManager) scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        bitcoinCounter.SetText(""+ScoreManager.availableCoins);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendDialogueWindowText(string message) {
        //print(message+"\n");
        TextWindow.GetComponent<TextMeshProUGUI>().SetText(message);
        //Handles updating the bitcoin if we haven't already done so
        bitcoinCounter.SetText(""+ScoreManager.availableCoins);

    }

    public void sendDialogueWindowWorldContext() {
        int rand = Random.Range(1, 10);
        if(rand > 5) {
            int worldContextSelector = Random.Range (0, worldContextItems.Length);
            print("Playing item number "+worldContextSelector+"\n");
            TextWindow.GetComponent<TextMeshProUGUI>().SetText(worldContextItems[worldContextSelector]);
        }
        else {
            TextWindow.GetComponent<TextMeshProUGUI>().SetText("");
            print("Unlucky!\n");
        }
    }

    public void TestShopFunctionalitySceneLoader() {
        if(GameManager.currentLevel==1) {
            SceneManager.LoadScene("Level2");
        }
        if(GameManager.currentLevel==2) {
            SceneManager.LoadScene("Level3");
        }
        
    }

}
