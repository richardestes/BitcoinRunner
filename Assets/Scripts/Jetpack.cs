using UnityEngine;

public class Jetpack : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        if (!gameManager) gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Harvestable"))
        {
            gameManager.IncreaseScore(10);
            Destroy(collision.gameObject);
        }
    }
}
