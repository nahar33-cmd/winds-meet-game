using UnityEngine;
using System.Collections.Generic;

// This script manages the skill tree system
public class SkillTree : MonoBehaviour
{
    // Skill enum
    public enum Skill
    {
        StrengthBoost,      // +damage
        DefenseBoost,       // +defense
        SpeedBoost,         // +movement speed
        StaminaPool,        // +max stamina
        CriticalChance,     // +chance to crit
        HealthPool,         // +max health
        ComboMastery,       // +combo damage
        AcrobaticsSkill     // +jump height
    }
    
    // Skill data class
    [System.Serializable]
    public class SkillData
    {
        public Skill skillType;
        public string skillName;
        public string description;
        public int cost;  // Skill points cost
        public int level = 0;  // Current level
        public int maxLevel = 5;  // Max level
        public float bonus;  // Bonus per level
    }
    
    // List of all skills
    [SerializeField] private List<SkillData> skills = new List<SkillData>();
    
    private int skillPoints = 0;  // Available skill points
    private CharacterStats playerStats;
    
    // Singleton pattern
    public static SkillTree Instance { get; private set; }
    
    // AWAKE - runs before Start
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    
    // START - runs once
    void Start()
    {
        playerStats = GetComponent<CharacterStats>();
        
        // Initialize all skills
        InitializeSkills();
        
        // Give player starting skill points
        skillPoints = 5;
    }
    
    // Function to initialize all skills
    void InitializeSkills()
    {
        skills.Add(new SkillData
        {
            skillType = Skill.StrengthBoost,
            skillName = "Strength Boost",
            description = "Increases damage dealt",
            cost = 1,
            bonus = 2f
        });
        
        skills.Add(new SkillData
        {
            skillType = Skill.DefenseBoost,
            skillName = "Defense Boost",
            description = "Reduces damage taken",
            cost = 1,
            bonus = 1f
        });
        
        skills.Add(new SkillData
        {
            skillType = Skill.SpeedBoost,
            skillName = "Speed Boost",
            description = "Increases movement speed",
            cost = 1,
            bonus = 1.5f
        });
        
        skills.Add(new SkillData
        {
            skillType = Skill.StaminaPool,
            skillName = "Stamina Pool",
            description = "Increases maximum stamina",
            cost = 2,
            bonus = 20f
        });
        
        skills.Add(new SkillData
        {
            skillType = Skill.CriticalChance,
            skillName = "Critical Strike",
            description = "Chance to deal 2x damage",
            cost = 3,
            bonus = 5f  // 5% per level
        });
        
        skills.Add(new SkillData
        {
            skillType = Skill.HealthPool,
            skillName = "Health Pool",
            description = "Increases maximum health",
            cost = 2,
            bonus = 25f
        });
        
        skills.Add(new SkillData
        {
            skillType = Skill.ComboMastery,
            skillName = "Combo Mastery",
            description = "Increases combo damage bonus",
            cost = 3,
            bonus = 3f  // 3% per level
        });
        
        skills.Add(new SkillData
        {
            skillType = Skill.AcrobaticsSkill,
            skillName = "Acrobatics",
            description = "Increases jump height",
            cost = 1,
            bonus = 1f
        });
    }
    
    // Function to level up a skill
    public bool LevelUpSkill(Skill skillType)
    {
        SkillData skill = skills.Find(s => s.skillType == skillType);
        
        if (skill == null)
        {
            Debug.Log("Skill not found!");
            return false;
        }
        
        // Check if skill is already maxed
        if (skill.level >= skill.maxLevel)
        {
            Debug.Log(skill.skillName + " is already maxed!");
            return false;
        }
        
        // Check if we have enough skill points
        if (skillPoints < skill.cost)
        {
            Debug.Log("Not enough skill points! Need " + skill.cost + ", have " + skillPoints);
            return false;
        }
        
        // Level up the skill
        skillPoints -= skill.cost;
        skill.level++;
        
        Debug.Log(skill.skillName + " leveled up to " + skill.level);
        ApplySkillBonus(skill);
        
        return true;
    }
    
    // Function to apply skill bonuses
    void ApplySkillBonus(SkillData skill)
    {
        // TODO: Apply bonuses to player stats
        // This would require modifying CharacterStats to be more dynamic
        Debug.Log(skill.skillName + " applied! Bonus: " + (skill.bonus * skill.level));
    }
    
    // Function to gain skill points (when leveling up)
    public void GainSkillPoints(int amount)
    {
        skillPoints += amount;
        Debug.Log("Gained " + amount + " skill points! Total: " + skillPoints);
    }
    
    // Getters
    public int GetSkillPoints() { return skillPoints; }
    public SkillData GetSkill(Skill skillType) { return skills.Find(s => s.skillType == skillType); }
    public List<SkillData> GetAllSkills() { return skills; }
}
