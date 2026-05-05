using UnityEngine;

// This script tracks player health, stamina, and stats
public class CharacterStats : MonoBehaviour
{
    // Health and Stamina
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float staminaRegenRate = 10f;  // Stamina gained per second
    
    private float currentHealth;
    private float currentStamina;
    
    // Stats (like attack power, defense, etc.)
    [SerializeField] private float strength = 10f;      // Damage multiplier
    [SerializeField] private float defense = 5f;        // Damage reduction
    [SerializeField] private float dexterity = 8f;      // Speed multiplier
    
    // START - runs once when game starts
    void Start()
    {
        // Set health and stamina to max at start
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }
    
    // UPDATE - runs every frame
    void Update()
    {
        // Regenerate stamina every frame
        RegenerateStamina();
    }
    
    // Function to take damage (like losing health)
    public void TakeDamage(float damageAmount)
    {
        // Reduce damage by defense
        float actualDamage = damageAmount - (defense * 0.1f);
        
        // Make sure damage is at least 1
        if (actualDamage < 1) actualDamage = 1;
        
        // Subtract from health
        currentHealth -= actualDamage;
        
        // Print to console for debugging
        Debug.Log("Player took " + actualDamage + " damage! Health: " + currentHealth);
        
        // If health reaches 0, player dies
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    // Function to use stamina (for attacking, sprinting, etc.)
    public bool UseStamina(float staminaCost)
    {
        // Check if we have enough stamina
        if (currentStamina >= staminaCost)
        {
            // Use the stamina
            currentStamina -= staminaCost;
            return true;  // Success
        }
        
        // Not enough stamina
        return false;  // Failed
    }
    
    // Function to regenerate stamina over time
    void RegenerateStamina()
    {
        // If stamina is less than max, add some back
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            
            // Don't let stamina go over max
            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
            }
        }
    }
    
    // Function when player dies
    void Die()
    {
        Debug.Log("Player died!");
        // TODO: Add death sequence later
        Destroy(gameObject);
    }
    
    // Getters (functions to GET information)
    // Like Scratch "my variable" block
    public float GetHealth() { return currentHealth; }
    public float GetMaxHealth() { return maxHealth; }
    public float GetStamina() { return currentStamina; }
    public float GetMaxStamina() { return maxStamina; }
    public float GetStrength() { return strength; }
    public float GetDefense() { return defense; }
}
