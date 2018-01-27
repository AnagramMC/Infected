using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour {
    public float speed;
    public int damage;
    public float rateOfFire;
    public float lifeTime;

    public GameObject[] bullets;

    private float currentTime;
    private Rigidbody2D[] rb;
	// Use this for initialization
	void Awake ()
    {
		for (int i = 0; i < bullets.Length; i++)
        {
            rb[i] = bullets[i].GetComponent<Rigidbody2D>();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentTime += Time.deltaTime;
        if (currentTime > lifeTime)
        {
            Destroy(this.gameObject);
        }
	}

    public void Shoot(Vector2 direction)
    {
        rb[0].velocity = direction * speed;
        rb[1].velocity = direction * speed;
        rb[2].velocity = direction * speed;
        rb[3].velocity = direction * speed;
        rb[4].velocity = direction * speed;
    }
}
