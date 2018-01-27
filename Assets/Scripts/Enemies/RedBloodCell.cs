﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCell : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;

    public float speed;

    private Vector3 originalPosition;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Attack()
    {
       
        Player = GameObject.Find("Player");

        Vector3 dir = Player.transform.position - transform.position;

        dir.Normalize();

        rb.velocity = dir * speed;

    }

    public void ReturnPosition()
    {
        transform.position = originalPosition;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag =="Border")
        {
            gameObject.SetActive(false);
            ReturnPosition();
        }
    }
}
