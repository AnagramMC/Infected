using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDownwards : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public bool ShouldMove = true;

    void FixedUpdate()
    {
        //if object should move then it will move with that code underneath 
        if (ShouldMove)
        {
            //move this shit to the down
            
            transform.position += moveSpeed * -transform.up * Time.deltaTime;
            //transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
    //upon impact call this to stop movement for explosion to spawn
    public bool StopMovement()
    {
        ShouldMove = false;
        return enabled = false;
    }
}
