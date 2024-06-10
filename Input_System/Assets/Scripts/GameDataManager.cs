using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameDataManager : MonoBehaviour
{
    private GameData gameData;

    private List<IGameData> GameDataObjects;
    public static GameDataManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Game Data Manager in the scene.");
        }
        Instance = this;
    }

    private void Start()
    {
        LoadGame();
       // this.GameDataObjects = FindAllGameDataObjects();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {


        if (this.gameData == null)
        {
            Debug.Log("No data was found.");
            NewGame();
        }
    }

    public void SaveGame()
    {

    }

    private void OnApplicationQuit()
    {
        SaveGame(); 
    }

    //private List<IGameData> FindAllGameDataObjects()
}
