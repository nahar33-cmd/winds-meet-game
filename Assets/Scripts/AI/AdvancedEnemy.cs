using UnityEngine;
using System;

// Advanced enemy with different types and behaviors
public class AdvancedEnemy : MonoBehaviour
{
    public enum EnemyType { Weak, Normal, Strong, Boss }
    
    // Stats based on type
    private float health;
    private float speed;
    private float attackDamage;
    private float detectionRange;
    private float attackRange;
    
    private float currentHealth;
    private Transform playerTransform;
    private float attackCooldown = 0f;
    
    // Event for when enemy dies
    public event Action OnDeath;
    
    // START - runs once
    void Start()
    {
        currentHealth = health;
        
        // Find player
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    // UPDATE - runs every frame
    void Update()
    {
        if (playerTransform == null) return;
        
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        
        if (distanceToPlayer < detectionRange)
        {
            ChasePlayer();
            
            if (distanceToPlayer < attackRange)
            {
                EnemyAttack();
            }
        }
        else
        {
            Wander();
        }
        
        if (attackCooldown > 0)
            attackCooldown -= Time.deltaTime;
    }
    
    // Function to set enemy type
    public void SetEnemyType(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Weak:
                health = 20f;
                speed = 2f;
                attackDamage = 3f;
                detectionRange = 8f;
                attackRange = 1.5f;
                GetComponent<Renderer>().material.color = Color.green;
                break;
            
            case EnemyType.Normal:
                health = 30f;
                speed = 3f;
                attackDamage = 5f;
                detectionRange = 10f;
                attackRange = 2f;
                GetComponent<Renderer>().material.color = Color.yellow;
                break;
            
            case EnemyType.Strong:
                health = 50f;
                speed = 2.5f;
                attackDamage = 8f;
                detectionRange = 12f;
                attackRange = 2.5f;
                GetComponent<Renderer>().material.color = Color.red;
                break;
            
            case EnemyType.Boss:
                health = 100f;
                speed = 2f;
                attackDamage = 15f;
                detectionRange = 15f;
                attackRange = 3f;
                GetComponent<Renderer>().material.color = Color.magenta;
                break;
        }
        
        currentHealth = health;
    }
    
    // Chase player
    void ChasePlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(playerTransform.position);
    }
    
    // Wander around
    void Wander()
    {
        transform.position += transform.forward * speed * 0.3f * Time.deltaTime;
    }
    
    // Attack
    void EnemyAttack()
    {
        if (attackCooldown > 0) return;
        
        attackCooldown = 2f;
        
        CharacterStats playerStats = playerTransform.GetComponent<CharacterStats>();
        if (playerStats != null)
        {
            playerStats.TakeDamage(attackDamage);
            Debug.Log("Enemy attacked!");
        }
    }
    
    // Take damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
            Die();
    }
    
    // Die
    void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
