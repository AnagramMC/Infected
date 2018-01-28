using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    enum pickUpTypes {LIFE, SHOTGUN, TRISHOT, GRENADE}

    [SerializeField]
    pickUpTypes pickUp;


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            switch(pickUp)
            {
                case pickUpTypes.LIFE:
                    //Shotgun
                    break;

                case pickUpTypes.SHOTGUN:
                    //Tri Shot
                    break;

                case pickUpTypes.TRISHOT:
                    // Life
                    break;

                case pickUpTypes.GRENADE:
                    //Grenade
                    break;
            }

            //Destroy object? or Pool
        }
    }
}
