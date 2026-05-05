using UnityEngine;

// This script handles advanced combat with combos and different attack types
public class AdvancedCombatSystem : MonoBehaviour
{
    // Attack types
    public enum AttackType { Light, Heavy, Special }
    
    // Attack settings
    [SerializeField] private float lightAttackDamage = 5f;   // Quick, weak
    [SerializeField] private float heavyAttackDamage = 15f;  // Slow, strong
    [SerializeField] private float specialAttackDamage = 25f;  // Very strong
    
    [SerializeField] private float lightAttackCooldown = 0.3f;
    [SerializeField] private float heavyAttackCooldown = 1.0f;
    [SerializeField] private float specialAttackCooldown = 2.0f;
    
    [SerializeField] private float attackRange = 3f;
    
    private float attackTimer = 0f;  // Timer for cooldown
    private int comboCounter = 0;    // How many attacks in a row
    private float comboResetTimer = 0f;  // Timer to reset combo
    private float comboWindow = 1.5f;  // Time between attacks to keep combo
    
    private CharacterStats stats;
    
    // START - runs once
    void Start()
    {
        stats = GetComponent<CharacterStats>();
    }
    
    // UPDATE - runs every frame
    void Update()
    {
        // Count down timers
        if (attackTimer > 0) attackTimer -= Time.deltaTime;
        if (comboResetTimer > 0) comboResetTimer -= Time.deltaTime;
        else comboCounter = 0;  // Reset combo if timer runs out
        
        // Check for attacks
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E))
            TryLightAttack();
        if (Input.GetKeyDown(KeyCode.Mouse1))  // Right mouse button
            TryHeavyAttack();
        if (Input.GetKeyDown(KeyCode.Q))  // Q for special
            TrySpecialAttack();
    }
    
    // Function to try light attack
    void TryLightAttack()
    {
        if (attackTimer > 0) return;
        if (!stats.UseStamina(5f)) return;
        
        Attack(AttackType.Light, lightAttackDamage, lightAttackCooldown);
    }
    
    // Function to try heavy attack
    void TryHeavyAttack()
    {
        if (attackTimer > 0) return;
        if (!stats.UseStamina(20f)) return;
        
        Attack(AttackType.Heavy, heavyAttackDamage, heavyAttackCooldown);
    }
    
    // Function to try special attack
    void TrySpecialAttack()
    {
        if (attackTimer > 0) return;
        if (!stats.UseStamina(40f)) return;
        
        Attack(AttackType.Special, specialAttackDamage, specialAttackCooldown);
    }
    
    // Main attack function
    void Attack(AttackType type, float damage, float cooldown)
    {
        // Add combo bonus (each attack in combo does more damage)
        float comboDamage = damage * (1 + (comboCounter * 0.1f));
        
        // Increase combo counter
        comboCounter++;
        comboResetTimer = comboWindow;
        
        // Reset attack timer
        attackTimer = cooldown;
        
        Debug.Log(type + " Attack! Damage: " + comboDamage + " Combo: " + comboCounter);
        
        // Hit detection
        HitEnemies(comboDamage);
    }
    
    // Function to detect and damage enemies
    void HitEnemies(float damage)
    {
        // Create a sphere to find enemies
        Collider[] hits = Physics.OverlapSphere(
            transform.position + transform.forward * 2f,
            attackRange
        );
        
        foreach (Collider hit in hits)
        {
            if (hit.gameObject == gameObject) continue;  // Skip self
            
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("HIT! Damage: " + damage);
            }
        }
    }
}
