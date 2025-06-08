using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float minimumSpawnTime = 1f;

    [SerializeField]
    private float maximumSpawnTime = 3f;

    private Collider2D mapCollider;
    private float timeUntilSpawn;

    void Awake()
    {
        // Cari objek dengan tag "MapArea"
        GameObject mapObj = GameObject.FindGameObjectWithTag("Map Area");

        if (mapObj != null)
        {
            mapCollider = mapObj.GetComponent<Collider2D>();
            if (mapCollider == null)
            {
                Debug.LogError("Map ditemukan tapi tidak ada Collider2D-nya!");
            }
        }
        else
        {
            Debug.LogError("Tidak ditemukan GameObject dengan tag 'Map Area'");
        }

        SetTimeUntilSpawn();
    }

    void Update()
    {
        if (mapCollider == null) return;

        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0f)
        {
            Vector2 spawnPosition = GetRandomSpawnPositionInMap();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private Vector2 GetRandomSpawnPositionInMap()
    {
        Bounds bounds = mapCollider.bounds;
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        return new Vector2(randomX, randomY);
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
