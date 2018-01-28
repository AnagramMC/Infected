using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private static int score = 0;

    public Text scoreText;

	// Use this for initialization
	void Start ()
    {
        UpdateScore();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int addition)
    {
        score += addition;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

}
