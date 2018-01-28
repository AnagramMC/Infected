using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public BoxCollider2D playerCollision;
    public GameObject Camera;

    public bool dead = false;
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
   // public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;

    private CameraShake cameraShakeScript;
    private AudioController audioScript;
    private bool isDamaged = false;
    
    // Use this for initialization
    private void Awake()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        audioScript = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
        cameraShakeScript = Camera.GetComponent<CameraShake>();
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
        if (gameObject.activeSelf == true)
        {
            FindObjectOfType<ScoreManager>().LoseLife();
            isDamaged = false;
            //cameraShakeScript.Enable();
            StartCoroutine(RespawnWait(2));
        }
    }

    

    IEnumerator RespawnWait(int seconds)
    {
        if(audioScript)
        {
            audioScript.PlayerHit(transform.position);
        }
        playerCollision.enabled = false;
        dead = true;
        transform.parent.position = Camera.transform.Find("Death Location").transform.position;
        Debug.Log("RESPAWN WAIT");
        yield return new WaitForSeconds(seconds);
        isDamaged = false;
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
            if (!isDamaged)
            {
                
                OnDamage();

                isDamaged = true;

            }
        }
    }

}
