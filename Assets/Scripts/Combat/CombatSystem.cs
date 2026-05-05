using UnityEngine;

// This script handles all combat (attacking, hitting, etc.)
public class CombatSystem : MonoBehaviour
{
    // Attack settings
    [SerializeField] private float attackDamage = 10f;  // Base damage
    [SerializeField] private float attackCooldown = 0.5f;  // Time between attacks
    [SerializeField] private float attackRange = 2f;  // How far the attack reaches
    
    private float attackTimer = 0f;  // Timer counting down
    private CharacterStats stats;  // Reference to player stats
    
    // START - runs once
    void Start()
    {
        // Get the stats script from this same object
        stats = GetComponent<CharacterStats>();
    }
    
    // UPDATE - runs every frame
    void Update()
    {
        // Count down the attack timer
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;  // Subtract time that passed
        }
        
        // Check if player pressed Attack button (Left Mouse Click or Gamepad Button)
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E))
        {
            TryAttack();
        }
    }
    
    // Function to try attacking
    void TryAttack()
    {
        // Check if attack is ready (cooldown finished)
        if (attackTimer > 0)
        {
            Debug.Log("Attack is on cooldown!");
            return;  // Stop, can't attack yet
        }
        
        // Check if we have enough stamina
        float staminaCost = 10f;  // Costs 10 stamina to attack
        if (!stats.UseStamina(staminaCost))
        {
            Debug.Log("Not enough stamina to attack!");
            return;  // Stop, not enough stamina
        }
        
        // Do the attack!
        Attack();
    }
    
    // Function to perform the attack
    void Attack()
    {
        // Reset the cooldown timer
        attackTimer = attackCooldown;
        
        Debug.Log("ATTACK!");
        
        // Raycast (shoot an invisible line) to find enemies
        // Like Scratch "touching color?" but for objects
        RaycastHit[] hits = Physics.RaycastAll(
            transform.position + Vector3.up,  // Start from player + up
            transform.forward,                 // Direction forward
            attackRange                        // How far
        );
        
        // Check all objects the raycast hit
        foreach (RaycastHit hit in hits)
        {
            // Skip if we hit ourselves
            if (hit.collider.gameObject == gameObject)
                continue;
            
            // Check if we hit an enemy
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Deal damage to enemy
                enemy.TakeDamage(attackDamage);
                Debug.Log("HIT ENEMY! Damage: " + attackDamage);
            }
        }
    }
}
