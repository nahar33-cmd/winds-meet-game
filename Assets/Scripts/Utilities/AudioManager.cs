using UnityEngine;

// This script manages sound effects and music
public class AudioManager : MonoBehaviour
{
    // Audio source components
    private AudioSource musicSource;  // Background music
    private AudioSource sfxSource;    // Sound effects
    
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip itemPickupSound;
    [SerializeField] private AudioClip backgroundMusic;
    
    [SerializeField] private float sfxVolume = 0.7f;
    [SerializeField] private float musicVolume = 0.3f;
    
    // Singleton pattern
    public static AudioManager Instance { get; private set; }
    
    // AWAKE - runs before Start
    void Awake()
    {
        // Create singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // START - runs once
    void Start()
    {
        // Create audio sources
        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();
        
        // Set volumes
        musicSource.volume = musicVolume;
        sfxSource.volume = sfxVolume;
        
        // Play background music
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
    
    // Function to play attack sound
    public void PlayAttackSound()
    {
        if (attackSound != null)
            sfxSource.PlayOneShot(attackSound);
    }
    
    // Function to play hit sound
    public void PlayHitSound()
    {
        if (hitSound != null)
            sfxSource.PlayOneShot(hitSound);
    }
    
    // Function to play death sound
    public void PlayDeathSound()
    {
        if (deathSound != null)
            sfxSource.PlayOneShot(deathSound);
    }
    
    // Function to play item pickup sound
    public void PlayItemPickupSound()
    {
        if (itemPickupSound != null)
            sfxSource.PlayOneShot(itemPickupSound);
    }
}
