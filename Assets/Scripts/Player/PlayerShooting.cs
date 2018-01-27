using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;

    private Vector2 fireInput;
    private float fireAngle;
    private PlayerProjectile projectile;

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
        if (fireInput.sqrMagnitude > 0.0f)
        {
            fireAngle = Mathf.Atan2(fireInput.y, fireInput.x) * Mathf.Rad2Deg;
            GameObject curProjectile = Instantiate(projectilePrefab,transform.position, transform.rotation) as GameObject;
            PlayerProjectile projectileScript = curProjectile.GetComponent<PlayerProjectile>();
            projectileScript.Shoot(fireInput);
        }
	}
}
