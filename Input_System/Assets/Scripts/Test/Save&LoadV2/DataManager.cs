using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // In this script you tell it what data to save and load

    [Header("File Storage Config")]
    [Tooltip("Name the file whatever you want")]
    [SerializeField] private string fileName;
    [Tooltip("Choose to encrypt the data or not")]
    [SerializeField] private bool useEncryption;


    private void Awake()
    {
        // Load data if needed
    }

    public void SaveData<T>(T data)
    {

    }
}
