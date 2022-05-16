using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Range(30f,50f)]
    public float jumpPower = 50f;
    [Range(0.25f, 0.75f)]
    public float decelerationPower = .25f;
    public bool isGameOver = false;
    public TextMeshProUGUI gameOverText;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        gameOverText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isGameOver) // Reload scene on player death 
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Level1");
            }
        }
    }

    void FixedUpdate()
    {
        if (isGameOver) return; // disable input 
        if (Input.GetMouseButton(0))
        {
            _rb.AddForce(new Vector2(0, jumpPower),ForceMode2D.Force);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _rb.velocity *= decelerationPower;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            _rb.isKinematic = true;
            gameOverText.gameObject.SetActive(true);
        }
    }
}
