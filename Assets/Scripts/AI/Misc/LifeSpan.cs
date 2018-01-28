using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    public float LifeDuration;
    float CurrentHealth = 0;
    float IncrementTime = 1;
    bool DamagePlayer;
    public GameObject Explosion;

    void Start()
    {
        StartCoroutine(CountdownToLife());
    }

    IEnumerator CountdownToLife()
    {
        yield return new WaitForSeconds(LifeDuration);
        if (Explosion)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
        }

        ProjectilePoolManager pool = GameObject.Find("Enemy Projectile Pool").GetComponent<ProjectilePoolManager>();

        if (pool)
        {
            Debug.Log("Return");
            this.gameObject.SetActive(false);
            pool.ReturnProjectileToPool(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Border")
        {
            gameObject.SetActive(false);

            ProjectilePoolManager enemyProjectile = GameObject.Find("Enemy Projectile Pool").GetComponent<ProjectilePoolManager>();

            if(enemyProjectile)
            {
                enemyProjectile.ReturnProjectileToPool(this.gameObject);
            }
        }
    }
}
