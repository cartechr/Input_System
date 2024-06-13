using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All the game's active data

namespace DataSpace
{
    // Game Data
    [System.Serializable]
    public class StartScreen
    {
        public StartScreen()
        {

        }
    }

    // Level Data
    // Objectives, Collectibles, Environment States

    [System.Serializable]
    public class LevelData
    {



        public LevelData()
        {

        }
    }

    // Player Data
    // Stats, Inventory, Location within a level, etc.
    [System.Serializable]
    public class PlayerData
    {


        public PlayerData()
        {

        }
    }

    [System.Serializable]
    public class PlayerSettings
    {

        public PlayerSettings()
        {

        }

    }
}