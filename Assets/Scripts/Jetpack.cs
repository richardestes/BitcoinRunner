using UnityEngine;

public class Jetpack : MonoBehaviour
{
    private BoxCollider2D jetpackCollider;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        jetpackCollider = GetComponent<BoxCollider2D>();
        if (!scoreManager) scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Jetpack hit:" + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Tree"))
        {
            scoreManager.IncreaseScore(10);
            Destroy(collision.gameObject);
        }
    }
}
