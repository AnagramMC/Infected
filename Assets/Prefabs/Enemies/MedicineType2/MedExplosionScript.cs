using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedExplosionScript : MonoBehaviour {
    public GameObject medicine;
    private EnemyHealth enemyHealthScript;
	// Use this for initialization
	void Start () {
        enemyHealthScript = medicine.GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReturnToPool()
    {
        enemyHealthScript.ReturnToPool();
    }
}
