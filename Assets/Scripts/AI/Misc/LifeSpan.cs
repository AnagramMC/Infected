using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour {
    public float LifeDuration;
    float CurrentHealth = 0;
    float IncrementTime = 1;
    bool DamagePlayer;
    public GameObject Explosion;

    void Start()
    {
        StartCoroutine(CountdownToLife());
    }

    IEnumerator CountdownToLife()
    {
        yield return new WaitForSeconds(LifeDuration);
        if (Explosion)
        {
            Instantiate(Explosion, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
