﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    // Use this for initialization
    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Shoot(Vector2 direction)
    {
        rb.velocity = direction * speed;
        
        Debug.Log("Shoot!");
    }
}
