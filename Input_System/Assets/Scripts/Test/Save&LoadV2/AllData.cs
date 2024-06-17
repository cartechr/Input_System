using System;
using UnityEngine;

// All the game's active data

namespace DataSpace
{
    #region Settings

    [Serializable]
    public class SettingsData
    {
        // Changed Values
        public FullScreenMode fullscreenMode;
        public Resolution resolution;
        public SettingsData()
        {
            //Default values
            fullscreenMode = FullScreenMode.FullScreenWindow;
            //resolution = null;
        }

    }

    #endregion

    #region Save Slots
    // Game Data
    [Serializable]
    public class SlotData
    {
        public IntroData introData;
        public LevelData levelData;
        public PlayerData playerData;
        public SlotData()
        {
            introData = new IntroData();
            levelData = new LevelData();
            playerData = new PlayerData();
        }
    }

    #endregion

    #region Player

    // Stats, Inventory, Location within a level, etc.
    [Serializable]
    public class PlayerData
    {


        public PlayerData()
        {

        }
    }

    #endregion

    #region Game


    // Level Data
    // Objectives, Collectibles, Environment States

    [Serializable]
    public class IntroData
    {


        public IntroData()
        {

        }
    }

    [Serializable]
    public class LevelData
    {

        public LevelData()
        {

        }
    }

    [Serializable]

    public class Level2Data
    {


        public Level2Data()
        {

        }
    }

    [Serializable]
    public class Level3Data
    {


        public Level3Data()
        {

        }
    }

    #endregion
}