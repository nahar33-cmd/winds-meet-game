using UnityEngine;

// This script manages items and weapons
public class Item : MonoBehaviour
{
    public enum ItemType { Health, Stamina, Sword, Shield, Armor }
    
    [SerializeField] private ItemType itemType;
    [SerializeField] private float value = 10f;  // Health/stamina amount or damage boost
    [SerializeField] private float duration = 30f;  // How long the effect lasts
    
    private bool pickedUp = false;
    
    // START - runs once
    void Start()
    {
        // Destroy item after a while if not picked up
        Destroy(gameObject, 60f);
    }
    
    // TRIGGER - when something collides
    void OnTriggerEnter(Collider collider)
    {
        // Check if player picked it up
        if (collider.CompareTag("Player") && !pickedUp)
        {
            PickUp(collider.gameObject);
            pickedUp = true;
        }
    }
    
    // Function when item is picked up
    void PickUp(GameObject player)
    {
        CharacterStats stats = player.GetComponent<CharacterStats>();
        
        switch (itemType)
        {
            case ItemType.Health:
                stats.TakeDamage(-value);  // Negative damage = heal
                Debug.Log("Picked up Health +" + value);
                break;
            
            case ItemType.Stamina:
                // TODO: Add stamina boost
                Debug.Log("Picked up Stamina +" + value);
                break;
            
            case ItemType.Sword:
                // TODO: Add weapon to inventory
                Debug.Log("Picked up Sword! Damage +" + value);
                break;
            
            case ItemType.Shield:
                // TODO: Add defense boost
                Debug.Log("Picked up Shield! Defense +" + value);
                break;
            
            case ItemType.Armor:
                // TODO: Add armor
                Debug.Log("Picked up Armor!");
                break;
        }
        
        // Destroy the item
        Destroy(gameObject);
    }
}
