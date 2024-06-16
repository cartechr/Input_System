using System;

// All the game's active data

namespace DataSpace
{
    #region Settings

    [Serializable]
    public class SettingsData
    {
        // Changed Values

        public bool fullscreen;
        public int Int;
        public float hi;
        public float hi2;
        public float hi3;
        public float hi4;
        public float hi5;
        public float hi6;
        public float hi7;
        public float hi8;
        public SettingsData()
        {

            //Default values
            fullscreen = true;
            Int = 0;
            hi = 53;
            hi2 = 53;
            hi3 = 5356456464565465;
            hi4 = 55465465465464;
            hi5 = 5365465565465465;
            hi6 = 5345485945;
            hi7 = 5334535353543;
            hi8 = 533543543534543543;

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