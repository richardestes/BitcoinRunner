using UnityEngine;

public class Harvestable : MonoBehaviour
{
    public SFXManager sfxManager;
    void Start()
    {
        if (!sfxManager) sfxManager = GameObject.FindGameObjectWithTag("SFXManager").GetComponent<SFXManager>();
        Destroy(this, 10f); // failsafe 
    }

    public void Harvest()
    {
        sfxManager.PlaySFX();
    }
}
