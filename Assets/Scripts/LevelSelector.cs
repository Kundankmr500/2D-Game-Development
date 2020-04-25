
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public static LevelSelector Instance;
    public List<Button> AllLevelButtons;

    private void Awake()
    {
        InitAllLevel();
        SetInstance();
    }

    void SetInstance()
    {
        if (Instance == null)
            Instance = this;
        
    }


    public void InitAllLevel()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < AllLevelButtons.Count; i++)
        {
            if (i + 1 > levelReached)
            {
                AllLevelButtons[i].interactable = false;
                AllLevelButtons[i].GetComponent<LevelButton>().LockThisButton();
            }
            
        }
    }

}
