
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public static LevelOverController _instance;
    public static LevelOverController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<LevelOverController>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("LevelOverController");
                    _instance = container.AddComponent<LevelOverController>();
                }
            }
            return _instance;
        }
    }


    public void GoToThisLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }


    public void LevelButtonclick(int sceneIndex)
    {
        AudioManager.Instance.PlayButtonClick();
        GoToThisLevel(sceneIndex);
    }

    public void RestartCurrentLevel()
    {
        AudioManager.Instance.PlayButtonClick();
        GoToThisLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void CloseApplication()
    {
        AudioManager.Instance.PlayButtonClick();
        Application.Quit();
    }

    public void ProcessLevelSelection()
    {
        AudioManager.Instance.PlayButtonClick();
        PlayerPrefs.SetInt("levelReached", SceneManager.GetActiveScene().buildIndex + 1);
        GoToThisLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void ResatPlayerData()
    {
        AudioManager.Instance.PlayButtonClick();
        PlayerPrefs.DeleteAll();
        GoToThisLevel(0);
    }

}
