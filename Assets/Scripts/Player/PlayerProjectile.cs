using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    PlayerProjectilePoolManager pool;

    public float speed;
    public int damage;
    public float rateOfFire;
    private Rigidbody2D rb;

    // Use this for initialization
    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        pool = FindObjectOfType<PlayerProjectilePoolManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Shoot(Vector2 direction)
    {
        rb.velocity = direction.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Border")
        {
            this.gameObject.SetActive(false);
            pool.ReturnProjectileToPool(this.gameObject);
        }
    }
}
