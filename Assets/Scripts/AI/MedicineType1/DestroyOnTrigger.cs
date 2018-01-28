using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour {

    public GameObject ExplosionArt;
    public Animator pillAnim;

    private EnemyHealth healthScript;
    private AudioController audioScript;
    private void Awake()
    {
        healthScript = GetComponent<EnemyHealth>();
        audioScript = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        string curString = col.tag;

        if(curString=="Player")
        {
            audioScript.MedicineExplosion(transform.position);
            Instantiate(ExplosionArt, transform.position,transform.rotation);
            pillAnim.SetBool("isExploding", true);
            healthScript.OnDamage(1);
        }
    }
}
