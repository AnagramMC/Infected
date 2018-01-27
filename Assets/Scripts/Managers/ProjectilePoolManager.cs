using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePoolManager : MonoBehaviour
{

    public ObjectPool pool;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject MoveProjectileToTarget(Vector3 playerPostion, Quaternion playerRotation)
    {
        GameObject projectile = pool.GetObject();
        projectile.transform.position = playerPostion;
        projectile.transform.rotation = playerRotation;

        return projectile;
    }

    public void ReturnProjectileToPool(GameObject projectile)
    {
        pool.PlaceObject(projectile);
    }
}
