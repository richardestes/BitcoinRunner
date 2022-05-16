using UnityEngine;

public class Harvestable : MonoBehaviour
{
    void Start()
    {
        Destroy(this, 10f); // failsafe 
    }
}
