using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelHandler : MonoBehaviour
{

    public static LevelHandler Instance;
    public TextMeshProUGUI ScoreText;
    public List<GameObject> PlayerLifes;

    private int scoreValue;

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
            LevelOverController.Instance.GoToThisLevel(2);
        }

    }


    public void CheckCollidedObject(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            ProcessPlayerLife();
        }
        else if (collision.CompareTag("Finish"))
        {
            LevelOverController.Instance.GoToThisLevel(0);
        }
        else if (collision.CompareTag("Coin"))
        {
            ProcessCoin(collision.gameObject);
        }
        else if (collision.CompareTag("Destroyer"))
        {
            LevelOverController.Instance.GoToThisLevel(2);
        }
    }


}
