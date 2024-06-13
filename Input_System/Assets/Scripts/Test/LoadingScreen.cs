using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class LoadingScreen : MonoBehaviour
{
    public string mainmenuName;
    public Slider progressBar;
    public TextMeshProUGUI progressText;
    public GameObject loadingScreenUI;

    private void Start()
    {
        // Ensure the loading is initially hidden
        loadingScreenUI.SetActive(false);

        // start loading process
        StartCoroutine(LoadGameAsync());
    }

    private IEnumerator LoadGameAsync()
    {
        // Show loading screen
        loadingScreenUI.SetActive(true);

        // Load the game asychronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mainmenuName);

        // While the scene is not fully loaded, update the progress bar
        while (!asyncLoad.isDone)
        {
            float progess = Mathf.Clamp01(asyncLoad.progress / 1f);
            progressBar.value = progess;
            progressText.text = $"{Mathf.Round(progess *  100)}";

            yield return null; // Wait until next frame
        }
        
        // Hide loading screen when loading is complete
        loadingScreenUI.SetActive(false);
    }
}

