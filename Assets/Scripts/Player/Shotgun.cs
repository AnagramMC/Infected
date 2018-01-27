using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour {
    public float speed;
    public int damage;
    public float rateOfFire;

    private float currentTime;
    public Rigidbody2D[] rb;

    ProjectilePoolManager pool;
    // Use this for initialization
    void Awake ()
    {
        pool = GameObject.Find("ShotgunPool").GetComponent<ProjectilePoolManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void Shoot(Vector2 direction)
    {
        rb[0].velocity = direction * speed;
        rb[1].velocity = direction * speed;
        rb[2].velocity = direction * speed;
        rb[3].velocity = direction * speed;
        rb[4].velocity = direction * speed;
        rb[5].velocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Border")
        {
            this.gameObject.SetActive(false);
            pool.ReturnProjectileToPool(this.gameObject);
        }
    }
}
