using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public BoxCollider2D playerCollision;
    public GameObject Camera;

    private int lives = 3;

    public bool dead = false;

    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
   // public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;
    // Use this for initialization
    private void Awake()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    // Update is called once per frame
    void Update ()
    {
		if (startBlinking)
        {
            StartSpriteBlinkingEffect();
        }
	}

    public void OnDamage()
    {
        
        lives--;
        Debug.Log(lives);
        StartCoroutine(RespawnWait(2));
    }

    public void AddLife()
    {
        lives++;
    }

    IEnumerator RespawnWait(int seconds)
    {
        playerCollision.enabled = false;
        dead = true;
        transform.parent.position = Camera.transform.Find("Death Location").transform.position;
        Debug.Log("RESPAWN WAIT");
        yield return new WaitForSeconds(seconds);
        transform.parent.position = Camera.transform.Find("Spawn Location").transform.position;
        this.gameObject.SetActive(true);
        StartCoroutine(CollisionDelay(2));
    }

    IEnumerator CollisionDelay(int seconds)
    {
        Debug.Log("Collision!");
        startBlinking = true;
        yield return new WaitForSeconds(seconds);
        StopSpriteBlinkingEffect();
        playerCollision.enabled = true;
        dead = false;
    }

    private void StartSpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;  //make changes
            }
            else
            {
                transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = true;   //make changes
            }
        }
    }

    private void StopSpriteBlinkingEffect()
    {
        startBlinking = false;
        spriteBlinkingTotalTimer = 0.0f;
        transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = true;   // according to 
                                                                         //your sprite
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            OnDamage();
        }
    }

}
