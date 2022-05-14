using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject prevCeiling;
    public GameObject prevFloor;
    public GameObject ceiling;
    public GameObject floor;

    public GameObject prevBackground;
    public GameObject background;

    public GameObject obstaclePrefab;
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;

    public GameObject player;

    public float minObstacleY;
    public float maxObstacleY;

    public float minObstacleSpacing;
    public float maxObstacleSpacing;

    public float minObstacleScaleY;
    public float maxObstacleScaleY;

    private void Start()
    {
        //TODO: Loopify this shit
        obstacle1 = GenerateObstacle(player.transform.position.x + 10f);
        obstacle2 = GenerateObstacle(obstacle1.transform.position.x);
        obstacle3 = GenerateObstacle(obstacle2.transform.position.x);
        obstacle4 = GenerateObstacle(obstacle3.transform.position.x);

        //TODO: Spawn harvestables at start of run
    }

    GameObject GenerateObstacle(float referenceX)
    {
        GameObject obstacle = Instantiate(obstaclePrefab);
        SetObstacleTransform(obstacle, referenceX);
        return obstacle;
    }

    void SetObstacleTransform(GameObject obstacle, float referenceX)
    {
        obstacle.transform.position = new Vector3(referenceX + 10f + Random.Range(minObstacleSpacing, minObstacleSpacing), Random.Range(minObstacleY, maxObstacleY), 0);
        obstacle.transform.localScale = new Vector3(obstacle.transform.localScale.x, Random.Range(minObstacleScaleY, maxObstacleScaleY), obstacle.transform.localScale.z);
    }

    void Update()
    {
        // Update Position of Floor/Ceiling/BG for seamless level
        if (player.transform.position.x > (floor.transform.position.x -8.2f)) // Player has passed halfway through current section
        {
            var tempCeiling = prevCeiling;
            var tempFloor = prevFloor;
            //var tempBg = prevBackground;
            prevCeiling = ceiling;
            prevFloor = floor;
            //prevBackground = background;
            tempCeiling.transform.position += new Vector3(37.7f, 0, 0);
            tempFloor.transform.position += new Vector3(37.7f, 0, 0);
            //tempBg.transform.position += new Vector3(38.36f, 0, 20);
            ceiling = tempCeiling;
            floor = tempFloor;
            //background = tempBg;
        }
        // Update position of obstacles
        if (player.transform.position.x > obstacle2.transform.position.x)
        {
            var tempObstacle = obstacle1;
            obstacle1 = obstacle2;
            obstacle2 = obstacle3;
            obstacle3 = obstacle4;
            SetObstacleTransform(tempObstacle, obstacle3.transform.position.x);
            obstacle4 = tempObstacle;
        }
    }
}
