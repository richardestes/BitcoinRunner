using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        if (!gameManager) gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Destroy(gameObject, 0.3f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Explosion on "+collision.gameObject.tag+"!\n");
        if (collision.gameObject.CompareTag("Harvestable"))
        {
            gameManager.IncreaseScore(10);
            Destroy(collision.gameObject);
        }
    }

}
