# Setup Instructions

## Quick Start

### 1. Clone the Repository
```bash
git clone https://github.com/nahar33-cmd/winds-meet-game.git
cd winds-meet-game
```

### 2. Open in Unity
- Launch Unity Hub
- Click "Add project from disk"
- Select the `winds-meet-game` folder
- Open with Unity 2022 LTS or newer

### 3. Create Scene
- Right-click in Assets/Scenes
- Create → Scene → Name: "Game"
- Save it

### 4. Setup Canvas (for UI/HUD)
- Right-click in Hierarchy → UI → Canvas
- This will automatically create EventSystem

### 5. Add Player
- Right-click in Hierarchy → 3D Object → Capsule
- Name: "Player"
- Position: (0, 1, 0)
- Add Rigidbody component
- Tag as "Player"
- Attach these scripts:
  - PlayerController
  - CharacterStats
  - AdvancedCombatSystem
  - SkillTree
  - HUD (attach to Canvas instead)

### 6. Add Camera
- Right-click in Hierarchy → 3D Object → Cube
- Name: "CameraRig"
- Position: (0, 0, 0)
- Add CameraController script
- Assign Player transform in the script
- Delete the cube's renderer (we don't see it)

### 7. Add Enemies
- Right-click in Hierarchy → 3D Object → Capsule
- Name: "Enemy"
- Position: (5, 1, 0)
- Add AdvancedEnemy script
- Color it differently (material)

### 8. Add Ground
- Right-click in Hierarchy → 3D Object → Plane
- Scale: (20, 1, 20)
- Position Y: -0.5
- Tag as "Ground"

### 9. Add Skill Tree UI (New!)
- Create a new Canvas for Skill Tree
- Right-click on Canvas → UI → Panel → Name: "SkillTreePanel"
- Add Text for "Skill Points"
- Add Text for "Description"
- Create a Scroll View for skill buttons
- Attach SkillTreeUI script to Canvas
- Assign references in the script

### 10. Add Menu (Optional)
- Create UI Buttons for Start/Pause/Quit
- Attach MainMenu script to a GameObject
- Assign buttons to the script fields

## Controls
- **WASD** - Move
- **Shift** - Sprint
- **Space** - Jump
- **Left Mouse / E** - Light Attack
- **Right Mouse** - Heavy Attack
- **Q** - Special Attack
- **T** - Open/Close Skill Tree (NEW!)
- **ESC** - Pause/Menu

## What Each Script Does

### Player Scripts
- **PlayerController.cs** - Movement and jumping
- **CharacterStats.cs** - Health and stamina
- **AdvancedCombatSystem.cs** - Combat with combos
- **CameraController.cs** - Smooth camera follow

### Skill System (NEW!)
- **SkillTree.cs** - Manages all skills and levels
- **SkillTreeUI.cs** - Displays skill tree interface

### Enemy Scripts
- **AdvancedEnemy.cs** - Different enemy types
- **EnemySpawner.cs** - Spawns waves of enemies

### World Scripts
- **Item.cs** - Pickupable items and weapons

### UI/Audio Scripts
- **AudioManager.cs** - Sound effects and music
- **MainMenu.cs** - Start/pause/quit menu
- **HUD.cs** - Health and stamina bars

## Advanced Features Included

✅ **Camera System**
- Smooth follow camera
- Mouse look (optional)
- Adjustable distance and height

✅ **Combat System**
- Light attacks (quick, weak)
- Heavy attacks (slow, strong)
- Special attacks (very powerful)
- Combo system (damage increases per hit)

✅ **Skill Tree System (NEW!)**
- 8 different skills to upgrade
- Level up skills with skill points
- Different costs for different skills
- Max level of 5 for each skill

**Skills Include:**
- Strength Boost - More damage
- Defense Boost - Less damage taken
- Speed Boost - Faster movement
- Stamina Pool - More stamina
- Critical Strike - Chance for 2x damage
- Health Pool - More health
- Combo Mastery - Better combos
- Acrobatics - Higher jumps

✅ **Enemy Types**
- Weak (green) - Easy
- Normal (yellow) - Medium
- Strong (red) - Hard
- Boss (magenta) - Very Hard

✅ **Items & Weapons**
- Health pickups
- Stamina pickups
- Equipment pickups

✅ **Audio System**
- Background music
- Attack sounds
- Hit sounds
- Death sounds
- Item pickup sounds

✅ **Menu System**
- Start menu
- Pause/Resume
- Quit game
- ESC to pause

## Next Steps

1. Add sound files to the AudioManager
2. Create UI buttons for the menu
3. Add more enemy types
4. Create weapons with different stats
5. Add boss battles
6. Add quest system
7. Implement skill effects (apply bonuses to stats)

---

**You now have a full playable game with skill tree progression!** 🎮
