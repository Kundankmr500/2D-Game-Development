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


    public void LevelFinish()
    {
       
    }


    public void GoToThisLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
