using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemForSale : MonoBehaviour
{
    // Start is called before the first frame update

    public int currentBitcoins;
    public GameObject shopManager;

    //public GameManager gameManager;

    //How much the item costs to purchase
    public int itemCost;

    //References to the UI elements associated with the shop item

    public TextMeshProUGUI associatedButtonText;

    public Button associatedButton;

    public GameObject associatedImage;

    //Text used when the player purchases or hovers over an object
    public string hoverText;
    public string purchaseText;
    
    //Tracks what gameplay changes the sold object is tied to
    public bool enablesGrenadeLauncher;

    public bool enablesTShirtLauncher;

    public bool enablesWideFlameJetpack;
    public bool enablesGoldJetpack;

    public bool enablesNFT1;
    public bool enablesNFT2;
    public bool enablesNFT3;

    //Tracks if the object has been sold
    private bool sold;


    void Start()
    {
        sold = false;
        associatedButtonText.text = ""+itemCost;

        if(enablesGrenadeLauncher && GameManager.grenadeLauncherEnabled) {
            purchaseEffects();
            
        }
        if(enablesNFT1 && GameManager.NFT1Enabled) {
            purchaseEffects();
        }
        if(enablesNFT2 && GameManager.NFT2Enabled) {
            purchaseEffects();
        }
        if(enablesNFT3 && GameManager.NFT3Enabled) {
            purchaseEffects();
        }

        //if (!gameManager) gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //if (!scoreManager) scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void mouseHoverText() {
            shopManager.GetComponent<ShopDialogueManager>().sendDialogueWindowText(hoverText);
    }

    public void spendBitcoin() {
        if(ScoreManager.score >= itemCost) {
            ScoreManager.score -= itemCost;
            purchaseEffects();
            shopManager.GetComponent<ShopDialogueManager>().sendDialogueWindowText(purchaseText);
        }
    }
    public void purchaseEffects() {

        //Removes the image
        associatedImage.SetActive(false);

        //Disable the purchase button
        associatedButton.interactable = false;

        //Set button text to sold
        associatedButtonText.text = "SOLD!";

        if(enablesGrenadeLauncher) {
            GameManager.grenadeLauncherEnabled = true;
        }
        if(enablesWideFlameJetpack) {
            
        }
        if(enablesGoldJetpack) {

        }
        if(enablesTShirtLauncher) {

        }
        if(enablesNFT1) {
            GameManager.NFT1Enabled = true;
        }
        if(enablesNFT2) {
            GameManager.NFT2Enabled = true;
        }
        if(enablesNFT3) {
            GameManager.NFT3Enabled = true;
        }
        
        hoverText = purchaseText;

    }
    public void mouseExitText() {
            shopManager.GetComponent<ShopDialogueManager>().sendDialogueWindowWorldContext();
    }



}
