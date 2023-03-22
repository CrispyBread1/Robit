using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{   

    [SerializeField]
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public int  score;
    public int scoreToCompleteLevel;
    public GameObject LevelCompleteScreen;

    // Start is called before the first frame update
    void Start()
    {   
        if(instance == null)
        {
            instance = this;
        }
        
    }

    public void ChangeScore(int scoreValue)
    {
        score += scoreValue;
        text.text = "X" + score.ToString();

    }

    public void Update()
    {
        if(score >= scoreToCompleteLevel)
        {
            Debug.Log("levelCOMplete");
            LevelCompleteScreen.SetActive(true);
        }
    }
}
