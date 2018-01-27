using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
            PlayerProjectile playerProjectile = projectile.GetComponent<PlayerProjectile>();

            if(playerProjectile)
            {
                //playerProjectile.Shoot(dir);
            }
            //projectile.GetComponent<PlayerProjectile>().Shoot(mousePosition);


        }
	}
}
