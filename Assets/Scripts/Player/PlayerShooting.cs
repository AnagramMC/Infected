using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public PlayerProjectilePoolManager projectilePool;
    public float lifeTime;

    private Vector2 fireInput;
    private float fireAngle;
    private PlayerProjectile projectile;
    private float rateOfFire;
    private bool canShoot = true;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //get input of right stick
        fireInput = new Vector2(Input.GetAxisRaw("RightH"), Input.GetAxisRaw("RightV"));
        
        Debug.Log(fireInput);
        if (fireInput.sqrMagnitude > 0.0f && canShoot)
        {
            fireAngle = Mathf.Atan2(fireInput.y, fireInput.x) * Mathf.Rad2Deg;
            GameObject curProjectile = projectilePool.MoveProjectileToPlayer(transform.position, transform.rotation);
            curProjectile.SetActive(true);
            PlayerProjectile projectileScript = curProjectile.GetComponent<PlayerProjectile>();
            projectileScript.Shoot(fireInput);
            rateOfFire = projectileScript.rateOfFire;
            canShoot = false;
            StartCoroutine(ResetCanShoot());
        }
	}
    
    IEnumerator ResetCanShoot()
    {
        yield return new WaitForSeconds(rateOfFire);
        canShoot = true;
    }
}
