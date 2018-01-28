using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour {


    public GameObject respawnPoint;

    void OnTriggerEnter(Collider collision)
    {
        
        if(collision.gameObject.tag==("Background"))
        {
            GameObject curObject = collision.gameObject;
            curObject.transform.position = respawnPoint.transform.position; 
            
        }
    }


}
