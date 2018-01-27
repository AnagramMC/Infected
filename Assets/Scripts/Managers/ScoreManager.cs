using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private static int score;

	// Use this for initialization
	void Start ()
    {
		
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
    }

    public void UpdateScore()
    {
        // Change the text on screen to update to user the score? 
    }

}
