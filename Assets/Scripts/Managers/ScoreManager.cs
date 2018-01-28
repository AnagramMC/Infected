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
    public Text[] topScoresText;
    public GameObject player;
    public GameObject HUD;
    public GameObject GameOverMenu;

    private int[] topScores;

	// Use this for initialization
	void Start ()
    {
        UpdateScore();
        UpdateLife();

        topScores = new int[5];

        for(int i = 0; i < topScores.Length; i ++)
        {
            topScores[i] = 0;
        }

        TopScoresUpdate();
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
            player.SetActive(false);
            HUD.SetActive(false);
            GameOverMenu.SetActive(true);
            Time.timeScale = 0.0f;

            // GAME OVER
        }
    }

    public void TopScoresUpdate()
    {
        for(int i = 0; i < topScores.Length; i++)
        {
            topScoresText[i].text = topScores[i].ToString();
        }
    }

    public void CheckHighScores ()
    {
        int temp = 0;

        for(int i = topScores.Length - 1; i >= 0; i--)
        {
            if (score > topScores[i])
            {
                temp = topScores[i];
                topScores[i] = score;

                int temp2;
                for (int j = i; j >= 0; j--)
                {
                    temp2 = topScores[j];
                    topScores[j] = temp;
                    temp = temp2;
                }
            }
        }

        TopScoresUpdate();
    }
}
