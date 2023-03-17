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
}
