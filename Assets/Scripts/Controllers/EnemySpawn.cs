using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Set this in the Inspector.
    public float spawnInterval = 1.0f; // How often enemies spawn.
    public float spawnDistance = 10.0f; // How far from the player enemies spawn.

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }

        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (playerTransform == null)
        {
            return;
        }

        // Choose a random angle.
        float angle = Random.Range(0, 360);

        // Convert the angle to a direction.
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        // Calculate the spawn position.
        Vector3 spawnPosition = playerTransform.position + (Vector3)(direction * spawnDistance);

        // Create the enemy.
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Ensure the enemy is rotated towards the player.
        Vector2 directionToPlayer = (playerTransform.position - spawnPosition).normalized;
        enemy.transform.up = directionToPlayer;
    }
}
