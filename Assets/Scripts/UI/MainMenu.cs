using UnityEngine;
using UnityEngine.UI;

// This script manages the main menu
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;  // The menu UI
    [SerializeField] private GameObject gamePanel;  // The game UI
    [SerializeField] private Button playButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button quitButton;
    
    private bool isPaused = false;
    private Time pausedTime;
    
    // START - runs once
    void Start()
    {
        // Set up button clicks
        playButton.onClick.AddListener(PlayGame);
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);
        
        // Show menu at start
        ShowMenu();
    }
    
    // UPDATE - runs every frame
    void Update()
    {
        // Press ESC to pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
    
    // Function to show menu
    void ShowMenu()
    {
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        Time.timeScale = 1f;  // Unfreeze time
    }
    
    // Function to play game
    void PlayGame()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        Time.timeScale = 1f;  // Unfreeze time
        isPaused = false;
    }
    
    // Function to pause game
    void PauseGame()
    {
        gamePanel.SetActive(false);
        menuPanel.SetActive(true);
        Time.timeScale = 0f;  // Freeze time
        isPaused = true;
    }
    
    // Function to resume game
    void ResumeGame()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        Time.timeScale = 1f;  // Unfreeze time
        isPaused = false;
    }
    
    // Function to quit game
    void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
