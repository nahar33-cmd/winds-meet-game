using UnityEngine;

// This script makes enemies move and fight
public class Enemy : MonoBehaviour
{
    // Enemy stats
    [SerializeField] private float maxHealth = 30f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float attackDamage = 5f;
    [SerializeField] private float detectionRange = 10f;  // How far can enemy see
    [SerializeField] private float attackRange = 2f;  // How close to attack
    
    private float currentHealth;
    private Transform playerTransform;  // Reference to player
    private float attackCooldown = 0f;
    
    // START - runs once
    void Start()
    {
        currentHealth = maxHealth;
        
        // Find the player in the scene
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    // UPDATE - runs every frame
    void Update()
    {
        // Make sure we have a player reference
        if (playerTransform == null) return;
        
        // Calculate distance to player
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        
        // Check if player is in detection range
        if (distanceToPlayer < detectionRange)
        {
            // Chase player
            ChasePlayer();
            
            // Check if close enough to attack
            if (distanceToPlayer < attackRange)
            {
                EnemyAttack();
            }
        }
        else
        {
            // Player not detected, just wander
            Wander();
        }
        
        // Count down attack cooldown
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
    }
    
    // Function to chase the player
    void ChasePlayer()
    {
        // Get direction to player
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
        
        // Move toward player
        transform.position += directionToPlayer * speed * Time.deltaTime;
        
        // Rotate to face player
        transform.LookAt(playerTransform.position);
    }
    
    // Function to wander around
    void Wander()
    {
        // Simple wander: just move forward slowly
        transform.position += transform.forward * speed * 0.5f * Time.deltaTime;
    }
    
    // Function for enemy to attack
    void EnemyAttack()
    {
        // Check if attack is ready
        if (attackCooldown > 0) return;
        
        // Reset cooldown
        attackCooldown = 2f;  // Attack every 2 seconds
        
        // Damage the player
        CharacterStats playerStats = playerTransform.GetComponent<CharacterStats>();
        if (playerStats != null)
        {
            playerStats.TakeDamage(attackDamage);
            Debug.Log("Enemy attacked player!");
        }
    }
    
    // Function to take damage
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Enemy health: " + currentHealth);
        
        // If health reaches 0, enemy dies
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    // Function when enemy dies
    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);  // Remove from game
    }
}
