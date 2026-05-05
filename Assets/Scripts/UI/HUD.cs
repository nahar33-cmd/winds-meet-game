using UnityEngine;
using UnityEngine.UI;  // For UI elements

// This script displays the player's health and stamina on screen
public class HUD : MonoBehaviour
{
    // UI Elements
    [SerializeField] private Image healthBar;  // The health bar image
    [SerializeField] private Image staminaBar;  // The stamina bar image
    [SerializeField] private Text healthText;  // Text showing health number
    [SerializeField] private Text staminaText;  // Text showing stamina number
    
    private CharacterStats playerStats;  // Reference to player stats
    
    // START - runs once
    void Start()
    {
        // Get the player stats script
        playerStats = GetComponent<CharacterStats>();
    }
    
    // UPDATE - runs every frame
    void Update()
    {
        // Update the health bar
        // fillAmount goes from 0 to 1 (0% to 100%)
        float healthPercent = playerStats.GetHealth() / playerStats.GetMaxHealth();
        healthBar.fillAmount = healthPercent;
        healthText.text = "Health: " + playerStats.GetHealth() + " / " + playerStats.GetMaxHealth();
        
        // Update the stamina bar
        float staminaPercent = playerStats.GetStamina() / playerStats.GetMaxStamina();
        staminaBar.fillAmount = staminaPercent;
        staminaText.text = "Stamina: " + (int)playerStats.GetStamina() + " / " + (int)playerStats.GetMaxStamina();
    }
}
