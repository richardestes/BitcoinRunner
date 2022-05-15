using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        if (!gameManager) gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Explosion on "+collision.gameObject.tag+"!\n");
        if (collision.gameObject.CompareTag("Tree"))
        {
            gameManager.IncreaseScore(10);
            Destroy(collision.gameObject);
        }
    }
/**
         private void OnTriggerStay2D(Collider2D collision)
    {
        print("Explosion on "+collision.gameObject.tag+"!\n");
        if (collision.gameObject.CompareTag("Tree"))
        {
            gameManager.IncreaseScore(10);
            Destroy(collision.gameObject);
        }
    }
**/
    /**     private void OnCollisionStay2D(Collider2D collision)
    {
        print("Explosion on "+collision.gameObject.tag+"!\n");
        if (collision.gameObject.CompareTag("Tree"))
        {
            gameManager.IncreaseScore(10);
            Destroy(collision.gameObject);
        }
    } **/

}
