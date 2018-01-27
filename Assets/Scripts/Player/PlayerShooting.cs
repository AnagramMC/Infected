using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public enum WeaponTypes { MachineGun,Shotgun,TriGun}
    public WeaponTypes curWeaponType;
    public GameObject projectilePrefab;
    public ProjectilePoolManager projectilePool;
    public float lifeTime;
    public GameObject[] projectilePos;
    public GameObject projectilePivot;
    private Vector2 fireInput;
    private float degree;
    private float fireAngle;
    private PlayerProjectile projectile;
    private float rateOfFire;
    private bool canShoot = true;

    // Use this for initialization
    void Start ()
    {
	    	
	}
	
    public void ChangeWeaponType(WeaponTypes newWeaponType)
    {
        curWeaponType = newWeaponType;
    }

	// Update is called once per frame
	void Update ()
    {
        //get input of right stick
        fireInput = new Vector2(Input.GetAxisRaw("RightH"), Input.GetAxisRaw("RightV"));
        
        switch(curWeaponType)
        {
            case WeaponTypes.MachineGun:
                if (fireInput.sqrMagnitude > 0.0f && canShoot)
                {
                    fireAngle = Mathf.Atan2(fireInput.y, fireInput.x) * Mathf.Rad2Deg;
                    projectilePivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, fireAngle));
                    GameObject curProjectile = projectilePool.MoveProjectileToTarget(projectilePos[0].transform.position, projectilePos[0].transform.rotation);
                    curProjectile.SetActive(true);
                    PlayerProjectile projectileScript = curProjectile.GetComponent<PlayerProjectile>();
                    projectileScript.changeLifeSpan(2);
                    projectileScript.StartTimer();
                    projectileScript.Shoot(fireInput);
                    rateOfFire = projectileScript.rateOfFire;
                    canShoot = false;
                    StartCoroutine(ResetCanShoot());
                }
                break;
            case WeaponTypes.Shotgun:
                if (fireInput.sqrMagnitude > 0.0f && canShoot)
                {
                    fireAngle = Mathf.Atan2(fireInput.y, fireInput.x) * Mathf.Rad2Deg;
                    for (int i = 0; i <= projectilePos.Length - 1; i++)
                    {
                        fireAngle = Mathf.Atan2(fireInput.y, fireInput.x) * Mathf.Rad2Deg;
                        projectilePivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, fireAngle));
                        
                        GameObject curProjectile = projectilePool.MoveProjectileToTarget(projectilePos[i].transform.position, projectilePos[i].transform.rotation);
                        PlayerProjectile projectileScript = curProjectile.GetComponent<PlayerProjectile>();
                        projectileScript.changeLifeSpan(0.25f);
                        curProjectile.SetActive(true);
                        projectileScript.StartTimer();
                        projectileScript.Shoot(projectilePos[i].transform.right);
                        rateOfFire = projectileScript.lifeSpan;

                        canShoot = false;
                        StartCoroutine(ResetCanShoot());
                    }
                }
                break;
            case WeaponTypes.TriGun:
                if (fireInput.sqrMagnitude > 0.0f && canShoot)
                {
                    fireAngle = Mathf.Atan2(fireInput.y, fireInput.x) * Mathf.Rad2Deg;
                    for (int i = 0; i <= 2; i++)
                    {
                        fireAngle = Mathf.Atan2(fireInput.y, fireInput.x) * Mathf.Rad2Deg;
                        GameObject curProjectile = projectilePool.MoveProjectileToTarget(projectilePos[i].transform.position, projectilePos[i].transform.rotation);
                        curProjectile.SetActive(true);
                        PlayerProjectile projectileScript = curProjectile.GetComponent<PlayerProjectile>();
                        projectileScript.changeLifeSpan(2);
                        projectileScript.StartTimer();
                        projectileScript.Shoot(projectilePos[i].transform.up);
                        rateOfFire = projectileScript.rateOfFire;
                    }
                    canShoot = false;
                    StartCoroutine(ResetCanShoot());
                }
                break;
        }

        Debug.Log(fireInput);
       
	}
    
    IEnumerator ResetCanShoot()
    {
        yield return new WaitForSeconds(rateOfFire);
        canShoot = true;
    }
}
