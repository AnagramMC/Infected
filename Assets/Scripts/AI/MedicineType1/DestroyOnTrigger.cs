using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour {

    public GameObject ExplosionArt;
    public Animator pillAnim;

    private EnemyHealth healthScript;

    private void Awake()
    {
        healthScript = GetComponent<EnemyHealth>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        string curString = col.tag;

        if(curString=="Player")
        {
            Instantiate(ExplosionArt, transform.position,transform.rotation);
            pillAnim.SetBool("isExploding", true);
            healthScript.OnDamage(1);
        }
    }
}
