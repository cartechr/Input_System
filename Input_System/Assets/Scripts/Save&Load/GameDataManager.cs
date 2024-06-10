using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class GameDataManager : MonoBehaviour
{
    [Header("File Storage Config")]

    [SerializeField] private string fileName;

    [SerializeField] private bool useEncryption;

    //reference to GameData script
    private GameData gameData;

    private List<IGameData> gameDataObjects;

    private FileDataHandler dataHandler;

    //Script Instance
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
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        this.gameDataObjects = FindAllGameDataObjects();
        LoadGame();
    }

    public void NewGame()
    {
        //Does it need to delete the previous one?
        this.gameData = new GameData();
        //this.gameData = new GameData().gameObject.AddComponent<GameData>();

        //Debug.Log("Creating New Game");
    }

    public void LoadGame()
    {
        //Load any saved data from a file using the data handler
        this.gameData = dataHandler.Load();

        // if no data can be Loaded, initialize to a new game
        if (this.gameData == null)
        {
            //Debug.Log("No data was found.");
            Debug.LogError("No data was found");
            NewGame();
        }

        foreach(IGameData gameDataObj in gameDataObjects)
        {
            gameDataObj.LoadData(gameData);
        }

        Debug.Log("Game Data Loaded");
    }

    public void SaveGame()
    {
        foreach(IGameData gameDataObj in gameDataObjects)
        {
            gameDataObj.SaveData(gameData);
        }

        Debug.Log("Game Saved");

        // save that data to a file using the data handler
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame(); 
    }

    private List<IGameData> FindAllGameDataObjects()
    {
        //System.Linq
        IEnumerable<IGameData> gameDataObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IGameData>();

        return new List<IGameData>(gameDataObjects);
    }
}
