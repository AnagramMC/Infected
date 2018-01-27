using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCellProjectile : MonoBehaviour {
    

    // Medusa Movement Variables
    public float xSpeed = 5.0f;
    public float amplitude = 5.0f;
    public float frequency = 5.0f;

    int numberOfTicks;
    float x;
    float y;


    float coolDownTimer;
    float attackCoolDown = 1.0f;

    void Start()
    {
        //reset number of ticks
        numberOfTicks = 0;

    }

    

    void FixedUpdate()
    {
        //increment number ticks 
        numberOfTicks++;
        //calculate speed
        x = -xSpeed;
        //calculate amplitude
        y = amplitude * (Mathf.Sin(numberOfTicks * frequency * Time.deltaTime));
        //apply movement
        transform.Translate(x * Time.deltaTime, y * Time.deltaTime, 0);
        
    }

}
