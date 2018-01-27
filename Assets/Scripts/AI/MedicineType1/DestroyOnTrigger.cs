using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour {

    public GameObject ExplosionArt;

    void OnTriggerEnter2D(Collider2D col)
    {
        string curString = col.tag;

        if(curString=="Player")
        {
            Instantiate(ExplosionArt, transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
