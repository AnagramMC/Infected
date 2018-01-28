using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    ProjectilePoolManager pool;

    public float speed;
    public int damage;
    public float rateOfFire;
    private Rigidbody2D rb;
    public float lifeSpan = 2;
    // Use this for initialization
    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        pool = GameObject.Find("Player Projectile Pool").GetComponent<ProjectilePoolManager>();
    }

    public float changeLifeSpan(float newLifeSpan)
    {
        return lifeSpan = newLifeSpan;
    }

    

    public void StartTimer()
    {
        StartCoroutine(CountDownToReturn());
    }

    IEnumerator CountDownToReturn()
    {
        yield return new WaitForSeconds(lifeSpan);
        gameObject.SetActive(false);
        ReturnProjectile();
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
            
            ReturnProjectile();
        }
    }

    public void ReturnProjectile()
    {
        StopCoroutine(CountDownToReturn());
        pool.ReturnProjectileToPool(this.gameObject);
    }
}
