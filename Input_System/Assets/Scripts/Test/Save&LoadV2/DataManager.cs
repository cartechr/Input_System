using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

namespace DataSpace
{
    public class DataManager : MonoBehaviour
    {
        [Header("File Storage Config")]
        [Tooltip("Name the file whatever you want")]
        [SerializeField] private string settingsFileName;
        [SerializeField] private string slot1FileName;
        [SerializeField] private string slot2FileName;
        [SerializeField] private string slot3FileName;
        [SerializeField] private string slot4FileName;
        [SerializeField] private string slot5FileName;

        [Tooltip("Choose to encrypt the data or not")]
        [SerializeField] private bool useEncryption;

        // Reference to class data handlers
        private DataHandler<Settings> settingsHandler;
        private DataHandler<Slot1> slot1Handler;
        private DataHandler<Slot2> slot2Handler;
        private DataHandler<Slot3> slot3Handler;
        private DataHandler<Slot4> slot4Handler;
        private DataHandler<Slot5> slot5Handler;

        // Singleton instance
        public static DataManager Instance { get; private set; }

        private void Awake()
        {
            // Ensure only one instance of DataManager exists
            if (Instance != null)
            {
                Debug.LogError("Found more than one Data Manager in the scene.");
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Initialize data handlers
            settingsHandler = new DataHandler<Settings>(Application.persistentDataPath, settingsFileName, useEncryption);
            slot1Handler = new DataHandler<Slot1>(Application.persistentDataPath, slot1FileName, useEncryption);
            slot2Handler = new DataHandler<Slot2>(Application.persistentDataPath, slot2FileName, useEncryption);
            slot3Handler = new DataHandler<Slot3>(Application.persistentDataPath, slot3FileName, useEncryption);
            slot4Handler = new DataHandler<Slot4>(Application.persistentDataPath, slot4FileName, useEncryption);
            slot5Handler = new DataHandler<Slot5>(Application.persistentDataPath, slot5FileName, useEncryption);
        }

        private void Start()
        {
            // Load settings data on start
            LoadData("Settings", settingsHandler);
        }

        public void LoadData<T>(string name, DataHandler<T> dataHandler) where T : class, new()
        {
            // Load saved data from file
            T loadData = dataHandler.Load();

            if (loadData == null)
            {
                Debug.LogError($"Error Loading Data - No {name} Data Found");
                NewGame(dataHandler); // Initialize new game if no data found
            }
            else
            {
                Debug.Log($"{name} data successfully loaded");
                // Continue with your game logic using loadData
            }
        }

        public void SaveData<T>(string name, T data, DataHandler<T> dataHandler) where T : class
        {
            // Save data to file
            dataHandler.Save(data);
            Debug.Log($"{name} data saved");
        }

        public void NewGame<T>(DataHandler<T> dataHandler) where T : class, new()
        {
            // Initialize new instance of T and save it
            T newData = new T();
            SaveData("New Game", newData, dataHandler);
            Debug.Log($"New game initialized for {typeof(T).Name}!");
        }

        private void OnApplicationQuit()
        {
            
        }

        private List<IData> FindAllGameDataObjects()
        {
            // Find all game data objects in the scene
            IEnumerable<IData> gameDataObjects = FindObjectsOfType<MonoBehaviour>().OfType<IData>();
            return new List<IData>(gameDataObjects);
        }
    }
}