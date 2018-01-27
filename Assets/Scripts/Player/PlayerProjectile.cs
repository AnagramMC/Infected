using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed;
    public int damage;

    private Rigidbody2D rb;
    public GameObject player;

    // Use this for initialization
    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Shoot(Vector2 direction)
    {
        rb.velocity = direction.normalized * speed;

       // Debug.Log("Shoot!");
    }
}
