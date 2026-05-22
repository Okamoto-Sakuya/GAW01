using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float rainDuration = 3f;
    public float minSpawnInterval = 0.01f;
    public float maxSpawnInterval = 0.05f;

    private BoxCollider spawnArea;

    private void Start()
    {
        spawnArea = GetComponent<BoxCollider>();
        if (spawnArea == null)
        {
            Debug.LogError("SpawnerÇ…ÇÕBoxColliderÇ™ïKóvÇ≈Ç∑ÅI");
            return;
        }

        StartCoroutine(RainRoutine());
    }

    IEnumerator RainRoutine()
    {
        while (true)
        {
            float endTime = Time.time + rainDuration;

            while (Time.time < endTime)
            {
                SpawnPrefab();
                float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
                yield return new WaitForSeconds(waitTime);
            }

            yield return null; // âJÇ™é~Çﬁéûä‘Çì¸ÇÍÇÈèÍçáÇÕÇ±Ç±Ç≈WaitForSeconds
        }
    }

    void SpawnPrefab()
    {
        if (prefabs.Length == 0) return;

        float xPos = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        float zPos = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);
        float yPos = spawnArea.bounds.max.y;

        Vector3 spawnPos = new Vector3(xPos, yPos, zPos);

        int index = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[index], spawnPos, Quaternion.identity);
    }
}