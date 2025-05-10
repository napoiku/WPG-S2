using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float minimumSpawnTime;

    [SerializeField]
    private float maximumSpawnTime;
    private float timeUntilSpawn;

    // Start is called before the first frame update
    void Awake()
    {
        setTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0) 
        {
            Vector2 spawnPosition = GetRandomSpawnPosition();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            setTimeUntilSpawn();
        }        
    }

    private Vector2 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(-240f, 240f); 
        float randomY = Random.Range(-240f, 240f); 
        return new Vector2(randomX, randomY);
    }

    private void setTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);

    }
}
