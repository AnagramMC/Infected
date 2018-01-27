using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    private Vector2 moveInput;
    private Vector2 moveVelocity;

    public float speed;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * speed;
        Debug.Log(moveInput);
    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }
}

