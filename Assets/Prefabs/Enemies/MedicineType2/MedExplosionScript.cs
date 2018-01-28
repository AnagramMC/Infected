using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedExplosionScript : MonoBehaviour {
    public GameObject medicine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReturnToPool()
    {
        Destroy(medicine);
    }
}
