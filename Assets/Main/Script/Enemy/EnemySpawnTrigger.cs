using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    // 複数のEnemyPrefab
    public GameObject[] enemyPrefabs;

    public int spawnCount = 3;
    public float spawnRange = 5f;

    // 何秒ごとにスポーン
    public float spawnInterval = 3f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemies), spawnInterval, spawnInterval);
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 offset = new Vector3(
                Random.Range(-spawnRange, spawnRange),
                0,
                Random.Range(-spawnRange, spawnRange)
            );

            Vector3 spawnPos = transform.position + offset;

            // ランダムなEnemyPrefab選択
            int randomIndex = Random.Range(0, enemyPrefabs.Length);

            GameObject randomEnemy = enemyPrefabs[randomIndex];

            Instantiate(randomEnemy, spawnPos, Quaternion.identity);
        }
    }
}