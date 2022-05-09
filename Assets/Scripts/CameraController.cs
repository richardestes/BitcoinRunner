using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController player;
    public float speed = 5f;
    void Update()
    {
        if (!player.isGameOver) transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
    }
}
