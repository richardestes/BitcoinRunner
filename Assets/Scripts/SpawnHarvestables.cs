using UnityEngine;
using System.Collections;

public class SpawnHarvestables : MonoBehaviour
{
    public GameObject[] harvestablePrefabs;

    public float spawnDistance = 4f;

    void Start()
    {
        StartCoroutine(HarvestableWave());
    }
    void SpawnHarvestable()
    {
        int randomIndex = Random.Range(0, harvestablePrefabs.Length - 1);
        spawnDistance = Random.Range(3f, 10f);
        GameObject harvestableObj = Instantiate(harvestablePrefabs[randomIndex]);
        harvestableObj.transform.position = new Vector3(transform.position.x + spawnDistance, transform.position.y + 0.1f);
    }

    IEnumerator HarvestableWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f,3f));
            SpawnHarvestable();
        }
    }

}
