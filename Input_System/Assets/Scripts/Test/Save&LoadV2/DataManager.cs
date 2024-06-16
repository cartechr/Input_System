using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using Unity.XR.GoogleVr;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using System;
using UnityEngine.Playables;

namespace DataSpace
{
    public class DataManager : MonoBehaviour
    {
        [Header("File Storage Config")]
        [Tooltip("Name the file whatever you want")]
        [SerializeField] private string settingsFileName;
        [SerializeField] private List<string> slotFileNames = new List<string>();

        [Tooltip("Choose to encrypt the data or not")]
        [SerializeField] private bool useEncryption;
        [SerializeField] private string encryptionKey;

        // Interface List
        private List<ISettingsData> settingsDataObjects;
        private List<ISlotsData> slotsDataObjects;

        // Class Handler Instances
        private DataHandler<SettingsData> settingsHandler;
        private List<DataHandler<SlotData>> slotHandlers = new List<DataHandler<SlotData>>();

        // Data Instances
        private SettingsData settingsData;
        private List<SlotData> slotData = new List<SlotData>();

        // Singleton instance
        public static DataManager Instance { get; private set; }

        private void Awake()
        {
            // Ensure only one instance of DataManager exists
            if (Instance != null)
            {
                Debug.LogError("Found more than one Data Manager in the scene.");
                Destroy(gameObject);
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (string.IsNullOrEmpty(encryptionKey) || encryptionKey.Length != 32 || encryptionKey.Contains(" "))
            {
                Debug.LogError("Error Loading Data - Ensure encryption key is formatted correctly");
                Debug.Log($"Encryption key is {encryptionKey.Length} characters long");
                return;
            }


            // Initialize data handlers
            settingsHandler = new DataHandler<SettingsData>(Application.persistentDataPath, settingsFileName, useEncryption, encryptionKey);

            for (int i = 0; i < slotFileNames.Count; i++)
            {
                if (!string.IsNullOrEmpty(slotFileNames[i]))
                {
                    slotHandlers.Add(new DataHandler<SlotData>(Application.persistentDataPath, slotFileNames[i], useEncryption, encryptionKey));
                    SlotData slot = new SlotData();
                }
                else
                {
                    Debug.LogError($"FileName at index {i} is not initialized correctly.");
                    return;
                    // Optionally handle or log the error
                }
            }
            //Debug.Log(settingsHandler.ToString());
            //Debug.Log(slotHandlers);
        }

        private void Start()
        {
            settingsDataObjects = FindAllSettingsDataObjects();
            slotsDataObjects = FindAllSlotsDataObjects();
            LoadSettings();

            Debug.Log($"Persistence path - \n{Application.persistentDataPath}");
        }

        #region Settings
        public void DefaultSettings()
        {
            this.settingsData = new SettingsData();
            SaveSettings();

            Debug.Log("Default Game Settings Applied");
        }

        public void LoadSettings()
        {
            this.settingsData = settingsHandler.Load();

            if (this.settingsData == null)
            {
                Debug.LogError("No settings data found");
                DefaultSettings();
            }

            foreach(ISettingsData settingsDataObj in settingsDataObjects)
            {
                settingsDataObj.SaveSettings(settingsData);
                Debug.Log(settingsDataObj.ToString());
            }

            Debug.Log("Saved Settings Loaded");
        }

        public void SaveSettings()
        {
            foreach (ISettingsData settingsDataObj in settingsDataObjects)
            {
                settingsDataObj.LoadSettings(settingsData);
            }


            settingsHandler.Save(settingsData);


            Debug.Log("Game Settings Saved");
        }
        #endregion

        #region Slot
        public void NewSlot(int index)
        {
            slotData[index] = new SlotData();
            SaveSlot(index);
        }

        public void LoadSlot(int listIndex)
        {
            // Check if listIndex is valid
            if (listIndex >= 0 && listIndex < slotHandlers.Count && listIndex < slotData.Count)
            {
                // Load saved data from file
                slotData[listIndex] = slotHandlers[listIndex].Load();

                if (slotData[listIndex] == null)
                {
                    Debug.LogError($"Error Loading Data - No {slotFileNames[listIndex]} Data Found");
                    NewSlot(listIndex); // Initialize new game if no data found
                }
                else
                {
                    foreach (ISlotsData slotDataObj in slotsDataObjects)
                    {
                        slotDataObj.LoadSlot(slotData[listIndex]);
                    }

                    Debug.Log($"{slotFileNames[listIndex]} data successfully loaded");
                    // Continue with your game logic using loadData
                }
            }
            else
            {
                Debug.LogError($"Invalid index {listIndex} for saving slot data.");
            }
        }

        public void SaveSlot(int listIndex)
        {
            // Check if listIndex is valid
            if (listIndex >= 0 && listIndex < slotHandlers.Count && listIndex < slotData.Count)
            {
                foreach (ISlotsData slotDataObj in slotsDataObjects)
                {
                    slotDataObj.SaveSlot(slotData[listIndex]);
                }

                // Save data to file
                slotHandlers[listIndex].Save(slotData[listIndex]);
                Debug.Log($"{slotFileNames[listIndex]} data saved");
            }
            else
            {
                Debug.LogError($"Invalid index {listIndex} for saving slot data.");
            }
        }
        #endregion

        private void OnApplicationQuit()
        {
            this.settingsData = null;

            for (int i = 0; i < slotData.Count; i++)
            {
                slotData[i] = null;
            }
        }

        private List<ISettingsData> FindAllSettingsDataObjects()
        {
            // Find all game data objects in the scene
            IEnumerable<ISettingsData> settingsDataObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISettingsData>();
            return new List<ISettingsData>(settingsDataObjects);
        }

        private List<ISlotsData> FindAllSlotsDataObjects()
        {
            // Find all game data objects in the scene
            IEnumerable<ISlotsData> slotsDataObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISlotsData>();
            return new List<ISlotsData>(slotsDataObjects);
        }
    }
}