using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public enum EnemyTypes {RedBlood,WhiteBlood,Med1,Med2 }
    public EnemyTypes CurrentEnemyType;
    private GameObject poolObject;
    private ObjectPool poolScript;
    public int maxHealth;
    private int health;

	// Use this for initialization
	void Awake ()
    {
        health = maxHealth;
        switch (CurrentEnemyType)
        {
            case EnemyTypes.RedBlood:
                poolObject = GameObject.FindGameObjectWithTag("RedBloodPool");
                break;
            case EnemyTypes.WhiteBlood:
                poolObject = GameObject.FindGameObjectWithTag("WhiteBloodPool");
                break;
            case EnemyTypes.Med1:
                poolObject = GameObject.FindGameObjectWithTag("Med1Pool");
                break;
            case EnemyTypes.Med2:
                poolObject = GameObject.FindGameObjectWithTag("Med2Pool");
                break;
        }
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
            
            health = maxHealth;

        }
    }

    public void ReturnToPool()
    {
        if(poolObject)
        {
            poolScript = poolObject.GetComponent<ObjectPool>();
            poolScript.PlaceObject(gameObject);
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
