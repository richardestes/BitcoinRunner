using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Range(30f,50f)]
    public float jumpPower = 50f;
    [Range(0.25f, 0.75f)]
    public float decelerationPower = .25f;

    public bool isGameOver = false;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Game");
            }
        }
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
        isGameOver = true;
        _rb.isKinematic = true;
    }
}
