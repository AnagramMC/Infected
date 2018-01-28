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
    public GameObject[] machinePos;
    public GameObject projectilePivot;
    public ScoreManager scoreManager;
    private SpawnManager spawnScript;
    

    private Vector2 fireInput;
    private float degree;
    private float fireAngle;
    private PlayerProjectile projectile;
    private float rateOfFire;
    private bool canShoot = true;

    // Use this for initialization
    void Awake ()
    {
        spawnScript = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
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
        //if(Input.GetButton("Fire1"))
        //{
        //    spawnScript.ClearAllCurrentEnemies();
        //}
        switch(curWeaponType)
        {
            case WeaponTypes.MachineGun:
                if (fireInput.sqrMagnitude > 0.0f && canShoot)
                {
                    fireAngle = Mathf.Atan2(fireInput.y, fireInput.x) * Mathf.Rad2Deg;
                    projectilePivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, fireAngle));
                    GameObject curProjectile = projectilePool.MoveProjectileToTarget(projectilePos[0].transform.position, projectilePos[0].transform.rotation);
                    PlayerProjectile projectileScript = curProjectile.GetComponent<PlayerProjectile>();
                    projectileScript.changeLifeSpan(2);
                    curProjectile.SetActive(true);
                    projectileScript.StartTimer();
                    projectileScript.Shoot(fireInput);
                    rateOfFire = projectileScript.rateOfFire ;
                    canShoot = false;
                    StartCoroutine(ResetCanShoot());
                }
                break;
            case WeaponTypes.Shotgun:
                if (fireInput.sqrMagnitude > 0.0f && canShoot)
                {
                    fireAngle = Mathf.Atan2(fireInput.y, fireInput.x) * Mathf.Rad2Deg;
                    for (int i = 0; i < projectilePos.Length; i++)
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
                    for (int i = 0; i < machinePos.Length; i++)
                    {
                        fireAngle = Mathf.Atan2(fireInput.y, fireInput.x) * Mathf.Rad2Deg;
                        projectilePivot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, fireAngle));
                        GameObject curProjectile = projectilePool.MoveProjectileToTarget(machinePos[i].transform.position, machinePos[i].transform.rotation);
                        PlayerProjectile projectileScript = curProjectile.GetComponent<PlayerProjectile>();
                        projectileScript.changeLifeSpan(1);
                        curProjectile.SetActive(true);
                        projectileScript.StartTimer();
                        projectileScript.Shoot(projectilePos[i].transform.right);
                        rateOfFire = 0.2f;

                        canShoot = false;
                        StartCoroutine(ResetCanShoot());
                    }
                }
                break;
        }

       
	}
    
    IEnumerator ResetCanShoot()
    {
        yield return new WaitForSeconds(rateOfFire);
        canShoot = true;
    }
}
