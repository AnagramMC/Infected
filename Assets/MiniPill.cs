﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPill : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.up * speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
