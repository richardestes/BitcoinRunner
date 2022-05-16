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

    public SFXManager sfxManager;

    // Start is called before the first frame update
    void Start()
    {

        if (!gameManager) gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (!sfxManager) sfxManager = GameObject.FindGameObjectWithTag("SFXManager").GetComponent<SFXManager>();

        transform.Translate(offsetPosition);
        Destroy(gameObject, 5); //Failsafe on failure to collide
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += thrownForce * Time.deltaTime * transform.right;
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
        if (collision.gameObject.CompareTag("Harvestable"))
        {
            Vector3 tempLoc = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            gameManager.IncreaseScore(10);
            collision.gameObject.GetComponent<Harvestable>().Harvest();
            Destroy(collision.gameObject);
            Instantiate(explosion, tempLoc, Quaternion.identity);
        }
        //Destroys object if it hits a obstacle or the background
        else if (collision.gameObject.CompareTag("CeilingTrigger") || collision.gameObject.CompareTag("FloorTrigger") || collision.gameObject.CompareTag("Obstacle"))
        {
            Vector3 tempLoc = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            Instantiate(explosion, tempLoc, Quaternion.identity);
        }
        sfxManager.PlayBombSFX();
        Destroy(this.gameObject);
    }
}
