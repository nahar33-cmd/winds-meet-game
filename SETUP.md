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

### 4. Add Player
- Right-click in Hierarchy → 3D Object → Capsule
- Name: "Player"
- Add Rigidbody component
- Tag as "Player"
- Drag PlayerController script onto it
- Drag CharacterStats script onto it
- Drag CombatSystem script onto it

### 5. Add Enemy
- Right-click in Hierarchy → 3D Object → Capsule
- Name: "Enemy"
- Change color (select material)
- Tag as "Enemy"
- Drag Enemy script onto it
- Position away from player

### 6. Add Ground
- Right-click in Hierarchy → 3D Object → Plane
- Scale to (10, 1, 10)
- Position Y to -1
- Tag as "Ground"
- Add collider

### 7. Test
- Press Play
- Move with WASD
- Sprint with Shift
- Jump with Space
- Attack with Mouse Click or E

## Controls
- **WASD** - Move
- **Shift** - Sprint
- **Space** - Jump
- **Mouse Click / E** - Attack

## What the Code Does

### PlayerController.cs
- Handles movement input
- Controls jumping
- Manages sprinting

### CharacterStats.cs
- Tracks health and stamina
- Handles damage
- Regenerates stamina

### CombatSystem.cs
- Player attacks
- Uses stamina for attacks
- Detects hit enemies

### Enemy.cs
- Chases player
- Attacks when close
- Takes damage
- Dies when health = 0

### HUD.cs
- Shows health bar
- Shows stamina bar
- Displays numbers

## Next Steps

What would you like to add?
1. Camera system (follow player)
2. Better combat (combos)
3. More enemies (waves)
4. Items/Weapons
5. Sound effects
6. Game menu

