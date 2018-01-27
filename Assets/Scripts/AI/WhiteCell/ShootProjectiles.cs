using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour {

    public GameObject[] ProjectilePos;
    public GameObject Projectile;
    public GameObject MuzzleArt;
    public float FireRate;
    float elapseTime;
    bool isReloading = false;
    public bool PlayerNear;

    void Awake()
    {
        //turn off muzzle art
        if (MuzzleArt)
        {
            MuzzleArt.SetActive(false);
        }
    }

    void FixedUpdate()
    {

        LaunchProjectiles();
    }


    void LaunchProjectiles()
    {

        if (PlayerNear)
        {
            //increment timer
            elapseTime += Time.deltaTime;
            if (elapseTime >= FireRate)
            {
                //get number of array size
                int PosLength = ProjectilePos.Length;
                //iterate through each projectile position to shoot the projectile from
                for (int i = 0; i < PosLength; i++)
                {
                    if (!isReloading)
                    {
                        if(MuzzleArt)
                        {
                            //enable muzzle art
                            MuzzleArt.SetActive(true);
                            //start countdown to reset muzzle
                            StartCoroutine(MuzzleShot());
                        }
                        //create projectile
                        Instantiate(Projectile, ProjectilePos[i].transform.position, ProjectilePos[i].transform.rotation);
                        
                    }
                }
                //cool down starts now
                isReloading = true;
                //reset timer
                elapseTime = 0;

            }
            else
            {
                //cool down is reset
                isReloading = false;
            }
        }
    }

    //after art is done playing turn off muzzle
    IEnumerator MuzzleShot()
    {
        yield return new WaitForSeconds(0.5f);
        if (MuzzleArt)
        {
            MuzzleArt.SetActive(false);
        }
    }

    //detection for player
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerNear = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerNear = false;
        }
    }
}
