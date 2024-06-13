using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManagerSpace
{
    public class GameManager : MonoBehaviour
    {
        // Manages overall game state, including high-level settings, progress, and global variables.


        // Instance script
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            // Make sure there's only one instance
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
