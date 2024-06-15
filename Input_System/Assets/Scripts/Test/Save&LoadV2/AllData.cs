using JetBrains.Annotations;
using System;

// All the game's active data

namespace DataSpace
{
    #region Settings

    [Serializable]
    public class Settings
    {
        // Leave alone

        public Settings()
        {

        }

    }

    #endregion

    #region Player

    // Stats, Inventory, Location within a level, etc.
    [Serializable]
    public class Player
    {


        public Player()
        {

        }
    }

    #endregion

    #region Save Slots
    // Game Data
    [Serializable]
    public class Slot1
    {
        public Intro introData;
        public Level levelData;
        public Player player;
        public Slot1()
        {
            introData = new Intro();
            levelData = new Level();
            player = new Player();
        }
    }

    [Serializable]
    public class Slot2
    {
        public Intro introData;
        public Level levelData;
        public Player player;

        public Slot2()
        {
            introData = new Intro();
            levelData = new Level();
            player = new Player();
        }
    }

    [Serializable]
    public class Slot3
    {
        public Intro introData;
        public Level levelData;
        public Player player;

        public Slot3()
        {
            introData = new Intro();
            levelData = new Level();
            player = new Player();
        }
    }

    public class Slot4
    {
        public Intro introData;
        public Level levelData;
        public Player player;
        public Slot4()
        {
            introData = new Intro();
            levelData = new Level();
            player = new Player();
        }
    }

    public class Slot5
    {
        public Intro introData;
        public Level levelData;
        public Player player;

        public Slot5()
        {
            introData = new Intro();
            levelData = new Level();
            player = new Player();

        }
    }

    #endregion

    #region Game


    // Level Data
    // Objectives, Collectibles, Environment States

    [Serializable]
    public class Intro
    {


        public Intro()
        {

        }
    }

    [Serializable]
    public class Level
    {

        public Level()
        {

        }
    }

    [Serializable]

    public class Level2
    {


        public Level2()
        {

        }
    }

    public class Level3
    {


        public Level3()
        {

        }
    }

    #endregion
}