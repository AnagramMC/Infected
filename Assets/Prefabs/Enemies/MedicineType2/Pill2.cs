﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill2 : MonoBehaviour
{
    public GameObject miniPillPrefab;
    public GameObject[] spawnPoints;
    private AudioController audioScript;
    public GameObject Target;
    public Animator pillAnim;

    public float speed;
    public float distanceCheck;

    private Rigidbody2D rb;

    private void Awake()
    {
        audioScript = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
    }

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = -transform.up * speed;
        Target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector3.Distance(transform.position, Target.transform.position);
        //Debug.Log(distance);
        if (distance <= distanceCheck && !pillAnim.GetBool("isExploding"))
        {
            Spread();
        }
	}

    public void Spread()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(miniPillPrefab, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
        }
        audioScript.MedicineExplosion(transform.position);
        pillAnim.SetBool("isExploding", true);
    }


}
