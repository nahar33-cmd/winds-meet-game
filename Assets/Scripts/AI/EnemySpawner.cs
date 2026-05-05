using UnityEngine;

// This script creates different types of enemies
public class EnemySpawner : MonoBehaviour
{
    // Enemy types
    public enum EnemyType { Weak, Normal, Strong, Boss }
    
    [SerializeField] private GameObject enemyPrefab;  // The enemy to spawn
    [SerializeField] private Transform[] spawnPoints;  // Where to spawn enemies
    [SerializeField] private int maxEnemies = 5;  // Max enemies at once
    
    private int currentEnemyCount = 0;
    
    // START - runs once
    void Start()
    {
        // Spawn initial enemies
        SpawnWave();
    }
    
    // UPDATE - runs every frame
    void Update()
    {
        // If enemies are dead, spawn more
        if (currentEnemyCount < maxEnemies)
        {
            SpawnEnemy(Random.Range(0, spawnPoints.Length), EnemyType.Normal);
        }
    }
    
    // Function to spawn a wave of enemies
    void SpawnWave()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            if (i < spawnPoints.Length)
            {
                EnemyType type = (EnemyType)(i % 3);  // Mix of types
                SpawnEnemy(i, type);
            }
        }
    }
    
    // Function to spawn one enemy
    void SpawnEnemy(int spawnPoint, EnemyType type)
    {
        if (spawnPoint >= spawnPoints.Length) return;
        
        // Instantiate enemy
        GameObject newEnemy = Instantiate(
            enemyPrefab,
            spawnPoints[spawnPoint].position,
            Quaternion.identity
        );
        
        // Get enemy script
        AdvancedEnemy enemyScript = newEnemy.GetComponent<AdvancedEnemy>();
        if (enemyScript != null)
        {
            enemyScript.SetEnemyType(type);
            enemyScript.OnDeath += () => currentEnemyCount--;  // Track death
        }
        
        currentEnemyCount++;
    }
}
