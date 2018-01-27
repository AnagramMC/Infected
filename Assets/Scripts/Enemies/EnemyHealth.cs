using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth;
    private int health;

	// Use this for initialization
	void Start ()
    {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            gameObject.SetActive(false);

            if (GetComponent<RedBloodCell>())
            {
                GetComponent<RedBloodCell>().ReturnPosition();
            }
            
            // Destroying logic with object pool, MAKE SURE TO RESET HEALTH AFTERT REMOVING
            //health = maxHealth;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player Projectile")
        {
            PlayerProjectile playerBullet = col.gameObject.GetComponent<PlayerProjectile>();

            if (playerBullet)
            {
                OnDamage(playerBullet.damage);
                playerBullet.ReturnProjectile();
            }


        }
    }
}
