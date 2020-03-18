using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelHandler : MonoBehaviour
{

    public static LevelHandler Instance;
    public TextMeshProUGUI ScoreText;

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


}
