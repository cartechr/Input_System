using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace DataSpace
{
    public class DataManager : MonoBehaviour
    {
        // In this script you tell it what data to save and load

        [Header("File Storage Config")]
        [Tooltip("Name the file whatever you want")]

        [SerializeField] private string playersettingsFileName;


        [SerializeField] private string[] FileNames;
        //[SerializeField] private

        [Tooltip("Choose to encrypt the data or not")]
        [SerializeField] private bool useEncryption;

        private DataHandler<PlayerSettings> playersettingsHandler;
        private void Awake()
        {
            this.playersettingsHandler = new DataHandler<PlayerSettings>(Application.persistentDataPath, playersettingsFileName, useEncryption);
        }

        //private void InitializeData<T>()

        public void NewGame()
        {

        }

        public void LoadGameData<T>(DataHandler<T> dataHandler) where T : class
        {
            // Example: Load game data of type T using the provided data handler
            T loadedData = dataHandler.Load();

            if (loadedData == null)
            {
                Debug.LogError("Error Loading Data");
            }
            else
            {
                Debug.Log($"Success: Loaded game data of type {typeof(T).Name}: {loadedData}");
            }
        }

        public void SaveData<T>(DataHandler<T> dataHandler) where T : class
        {
           // T savedData = dataHandler.Save
        }

        private void OnApplicationQuit()
        {
            
        }


        private string GetFilePath()
        {
            return Path.Combine(Application.persistentDataPath, $"{fileName}.json");
        }
    }
}
