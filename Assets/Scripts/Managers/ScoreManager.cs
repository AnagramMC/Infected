using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private static int score = 0;

    private int lives = 3;

    public Text scoreText;
    public Text lifeText;

	// Use this for initialization
	void Start ()
    {
        UpdateScore();
        UpdateLife();
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

    public void UpdateLife()
    {
        lifeText.text = lives.ToString();
    }

    public void AddLife()
    {
        lives++;
        UpdateLife();
    }

    public void LoseLife()
    {
        lives--;

        UpdateLife();

        if(lives <= 0)
        {
            // GAME OVER
        }
    }
}
