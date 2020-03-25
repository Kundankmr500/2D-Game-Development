using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public static LevelOverController Instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
            Instance = this;    
    }


    public void GoToThisLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    
    public void RestartCurrentLevel()
    {
        GoToThisLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    public void ProcessLevelSelection()
    {
        PlayerPrefs.SetInt("levelReached", SceneManager.GetActiveScene().buildIndex + 1);
        GoToThisLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void ResatPlayerData()
    {
        PlayerPrefs.DeleteAll();
        GoToThisLevel(0);
    }

}
