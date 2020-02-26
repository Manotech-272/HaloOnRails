using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    
    int score = 0;
    Text scoreText;

    public static ScoreBoard instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }



    public void ScoreHit(int scoreIncrement)
    {
        score += scoreIncrement;
    }
}
