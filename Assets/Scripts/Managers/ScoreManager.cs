using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private int score = 0;

    private int lives = 3;

    public Text scoreText;
    public Text lifeText;
    public Text[] topScoresText;
    public GameObject player;
    public GameObject HUD;
    public GameObject GameOverMenu;

    private static int[] topScores = {0, 0, 0 ,0 ,0};

	// Use this for initialization
	void Start ()
    {
        UpdateScore();
        UpdateLife();

        

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
            CheckHighScores();
            UpdateScore();
            player.SetActive(false);
            HUD.SetActive(false);
            GameOverMenu.SetActive(true);
            GameOverMenu.GetComponent<GameOver>().updateScreen(score);
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
        bool topScore = false;

        for(int i = 0; i < topScores.Length; i++)
        {
            if (!topScore)
            {
                if (score > topScores[i])
                {
                    temp = topScores[i];
                    topScores[i] = score;
                    topScore = true;

                }
            }
            else
            {
                int temp2 = topScores[i];
                topScores[i] = temp;
                temp = temp2;
            }
        }

        TopScoresUpdate();
    }
}
