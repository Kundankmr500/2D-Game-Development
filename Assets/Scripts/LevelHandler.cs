using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelHandler : MonoBehaviour
{
    public static int scoreValue;
    public static LevelHandler Instance;
    public TextMeshProUGUI ScoreText;
    public List<GameObject> PlayerLifes;
    public GameObject LevelCompleteOBj;
    public GameObject Player;
    public GameObject LevelObjects;
    


    // Start is called before the first frame update
    void Awake()
    {
        SetInstance();
    }

    private void Start()
    {
        InitDefaultValue();
    }


    void InitDefaultValue()
    {
        if(scoreValue == 0)
            ShowScore(0);
    }


    void SetInstance()
    {
        if (Instance == null)
            Instance = this;
    }


    public void ShowScore(int value)
    {
        scoreValue += value;
        ScoreText.text = "Score: - " + scoreValue;
    }

    public void ProcessCoin(GameObject coin)
    {
        coin.SetActive(false);
        ShowScore(10);
    }

    public void ProcessPlayerLife()
    {
        if(PlayerLifes.Count > 1)
        {
            int lifeIndex = PlayerLifes.Count - 1;
            PlayerLifes[lifeIndex].gameObject.SetActive(false);
            PlayerLifes.RemoveAt(lifeIndex);
        }
        else
        {
            LevelOverController.Instance.GoToThisLevel(5);
        }

    }


    public void CheckCollidedObject(Collider2D collision)
    {
        if (collision.GetComponent<Enamy>())
        {
            ProcessPlayerLife();
        }
        else if (collision.GetComponent<LevelCompleteGate>())
        {
            ShowLevelComplete();
        }
        else if (collision.GetComponent<Coin>())
        {
            ProcessCoin(collision.gameObject);
        }
        else if (collision.GetComponent<Destroyer>())
        {
            LevelOverController.Instance.GoToThisLevel(5);
        }
    }
    
    public void ShowLevelComplete()
    {
        LevelCompleteOBj.SetActive(true);
        Player.SetActive(false);
        LevelObjects.SetActive(false);
        
    }


}
