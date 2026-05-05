using UnityEngine;
using UnityEngine.UI;

// This script displays the skill tree UI
public class SkillTreeUI : MonoBehaviour
{
    [SerializeField] private Canvas canvas;  // The UI canvas
    [SerializeField] private GameObject skillButtonPrefab;  // Button template
    [SerializeField] private Transform skillContainer;  // Where to place buttons
    [SerializeField] private Text skillPointsText;  // Shows skill points
    [SerializeField] private Text descriptionText;  // Shows skill description
    
    private SkillTree skillTree;
    private bool isOpen = false;
    
    // START - runs once
    void Start()
    {
        skillTree = SkillTree.Instance;
        
        // Create skill buttons
        CreateSkillButtons();
        
        // Hide skill tree at start
        HideSkillTree();
    }
    
    // UPDATE - runs every frame
    void Update()
    {
        // Press T to open/close skill tree
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (isOpen)
                HideSkillTree();
            else
                ShowSkillTree();
        }
        
        // Update skill points display
        UpdateUI();
    }
    
    // Function to create skill buttons
    void CreateSkillButtons()
    {
        foreach (SkillTree.SkillData skill in skillTree.GetAllSkills())
        {
            // Create button
            GameObject buttonObj = Instantiate(skillButtonPrefab, skillContainer);
            Button button = buttonObj.GetComponent<Button>();
            Text buttonText = buttonObj.GetComponentInChildren<Text>();
            
            // Set button text
            buttonText.text = skill.skillName + "\n(" + skill.level + "/" + skill.maxLevel + ")";
            
            // Add click listener
            button.onClick.AddListener(() => OnSkillButtonClicked(skill));
        }
    }
    
    // Function when skill button is clicked
    void OnSkillButtonClicked(SkillTree.SkillData skill)
    {
        // Try to level up
        skillTree.LevelUpSkill(skill.skillType);
        
        // Update description
        descriptionText.text = skill.skillName + "\n" + skill.description +
                              "\nLevel: " + skill.level + "/" + skill.maxLevel +
                              "\nCost: " + skill.cost + " points";
    }
    
    // Function to update UI
    void UpdateUI()
    {
        skillPointsText.text = "Skill Points: " + skillTree.GetSkillPoints();
    }
    
    // Function to show skill tree
    void ShowSkillTree()
    {
        canvas.gameObject.SetActive(true);
        isOpen = true;
        Time.timeScale = 0f;  // Pause game
        Debug.Log("Skill Tree opened!");
    }
    
    // Function to hide skill tree
    void HideSkillTree()
    {
        canvas.gameObject.SetActive(false);
        isOpen = false;
        Time.timeScale = 1f;  // Resume game
        Debug.Log("Skill Tree closed!");
    }
}
