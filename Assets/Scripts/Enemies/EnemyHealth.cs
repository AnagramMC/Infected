using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public enum EnemyTypes {RedBlood,WhiteBlood,Med1,Med2,Projectile}
    public EnemyTypes CurrentEnemyType;

    private CameraShake cameraShakeScript;
    private GameObject poolObject;
    private ObjectPool poolScript;
    public int maxHealth;
    private int health;

    public int score;

	// Use this for initialization
	void Awake ()
    {
        health = maxHealth;
        switch (CurrentEnemyType)
        {
            //case EnemyTypes.RedBlood:
              //  poolObject = GameObject.FindGameObjectWithTag("RedBloodPool");
                //break;
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
        cameraShakeScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
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
            

            if (CurrentEnemyType == EnemyTypes.RedBlood)
            {
                GetComponent<RedBloodCell>().ReturnPosition();
            }


            if(GetComponent<MiniPill>())
            {
                Destroy(this.gameObject);
            }

            
            // Destroying logic with object pool, MAKE SURE TO RESET HEALTH AFTERT REMOVING
            
            health = maxHealth;

            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

            if(scoreManager)
            {
                scoreManager.AddScore(score);
            }

            gameObject.SetActive(false);


        }
    }

    public void ReturnToPool()
    {
        if(poolObject)
        {
            poolScript = poolObject.GetComponent<ObjectPool>();
            gameObject.SetActive(false);
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
                if (CurrentEnemyType != EnemyTypes.Projectile)
                {
                    OnDamage(playerBullet.damage);
                }
                playerBullet.ReturnProjectile();
                //cameraShakeScript.Enable();
            }


        }

       if(col.tag == "Border")
       {
           ReturnToPool();
       }
    }
}
