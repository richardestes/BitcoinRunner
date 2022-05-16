using UnityEngine;
using System.Collections;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    public float spawnDistance = 4f;

    void Start()
    {
        StartCoroutine(ObstacleWave());
    }
    void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePrefabs.Length - 1);
        spawnDistance = Random.Range(3f, 10f);
        GameObject obstacleObj = Instantiate(obstaclePrefabs[randomIndex]);
        float randomYPosition = Random.Range(-1f, 3f);
        obstacleObj.transform.position = new Vector3(transform.position.x + spawnDistance, randomYPosition);
        float randomScale = Random.Range(0.8f, 1.2f);
        obstacleObj.transform.localScale = new Vector3(randomScale, randomScale, 1);
    }

    IEnumerator ObstacleWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            SpawnObstacle();
        }
    }

}
