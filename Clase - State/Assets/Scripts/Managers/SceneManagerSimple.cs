using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerSimple : MonoBehaviour
{
    public static SceneManagerSimple Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        if (Instance != this )
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        int length = SceneManager.sceneCountInBuildSettings;

        if (nextIndex >= length)
        {
            nextIndex = 0;
        }

        SceneManager.LoadScene(nextIndex);

    }


}
