using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject prevCeiling;
    public GameObject prevFloor;
    public GameObject ceiling;
    public GameObject floor;

    public GameObject player;

    void Update()
    {
        // Update Position of Floor/Ceiling/BG for seamless level
        if (player.transform.position.x > (floor.transform.position.x -8.2f)) // Player has passed halfway through current section
        {
            var tempCeiling = prevCeiling;
            var tempFloor = prevFloor;
            prevCeiling = ceiling;
            prevFloor = floor;
            tempCeiling.transform.position += new Vector3(37.7f, 0, 0);
            tempFloor.transform.position += new Vector3(37.7f, 0, 0);
            ceiling = tempCeiling;
            floor = tempFloor;
        }

    }
}
