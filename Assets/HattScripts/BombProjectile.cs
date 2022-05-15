using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{

    //Starting position for object relative to player
    public Vector2 offsetPosition;

    //Increment at which vertical velocity drops
    //public float fallSpeed;
    //Starting vertical velocity
    public float initialVertical;

    //Horizontal velocity
    public float thrownForce;

    //Max vertical velocity
    //public float terminalVelocity;

    //Rate of horizontal velocity decline, unused for now
    public float thrownForceDropOff;

    //How big the bomb explosions are
    //public float explosionRadius;

    public GameManager gameManager;

    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {

         if (!gameManager) gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
        transform.Translate(offsetPosition);

        //Failsafe on failure to collide

        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {



        transform.position += transform.right * thrownForce * Time.deltaTime;
        thrownForce -= thrownForceDropOff;

        this.GetComponent<Rigidbody2D>().AddForce(transform.up * initialVertical);
        initialVertical /= 2;

        //Moves the bomb downwards and to the right
        //transform.position += (transform.up * initialVertical) - (transform.up * fallSpeed);
        //transform.position += transform.up * initialVertical;

        /**
        if(thrownForce > 0) {
            thrownForce -=thrownForceDropOff;
        }
        else if (thrownForce < 0) {
            thrownForce = 0;
        }
        **/
        //Allows us to manually adjust fall speed
        //if(fallSpeed < terminalVelocity) {
       //     fallSpeed += fallSpeed;

        //}
        //else if (fallSpeed > terminalVelocity) {
       //     fallSpeed = terminalVelocity;
       //}
    }

       private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Collided with "+collision.ToString()+"\n");
        if (collision.gameObject.CompareTag("Tree"))
        {
            Vector3 tempLoc = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            //gameManager.IncreaseScore(10);
            //Destroy(collision.gameObject);
            Instantiate(explosion, tempLoc, Quaternion.identity);
            Destroy(this.gameObject);
        }
        //Destroys object if it hits a obstacle or the background
        else if (collision.gameObject.CompareTag("CeilingTrigger") || collision.gameObject.CompareTag("FloorTrigger") || collision.gameObject.CompareTag("Obstacle"))
        {
            Vector3 tempLoc = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            Instantiate(explosion, tempLoc, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
