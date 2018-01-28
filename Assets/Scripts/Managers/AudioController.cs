using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    // Singleton instance 
    public static AudioController instance;

    [Header("BackgroundMusic")]
    public AudioSource BgMusicSource;
    public float bgMusicDelay;

    [Header("GameOverMusic")]
    public AudioSource GameOverSource;
    public float gameOverDelay;

    [Header("Player Hit")]
    public AudioSource playerHitSource;
    public float hitDelay;
    public float maxHitDelay;

    [Header("PowerUp")]
    public AudioSource powerUpSource;
    public float powerUpDelay;
    public float maxPowerUpDelay;


    // Audio timers
    float timer_01, timer_02;
    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        timer_01 += Time.deltaTime;
        timer_02 += Time.deltaTime;
    }

    public void BackgroundMusic()
    {
        if (timer_02 >= bgMusicDelay)
        {
            if (BgMusicSource != null)
            {
                BgMusicSource.priority = 200;
                BgMusicSource.volume = 0.25f;
                BgMusicSource.minDistance = 1000f;
                BgMusicSource.loop = true;
                BgMusicSource.Play();
            }
        }
    }
    public void GameOverMusic()
    {
        if (timer_02 >= gameOverDelay)
        {
            if (GameOverSource != null)
            {
                GameOverSource.priority = 200;
                GameOverSource.volume = 0.25f;
                GameOverSource.minDistance = 1000f;
                GameOverSource.loop = true;
                GameOverSource.Play();
            }
        }
    }
    public void PlayerHit(Vector3 pos)
    {
        if (timer_02 >= maxHitDelay)
        {

            if (playerHitSource != null)
            {
                playerHitSource.pitch = Random.Range(0.8f, 1f);
                playerHitSource.volume = Random.Range(0.8f, 1f);
                playerHitSource.minDistance = 20f;
                playerHitSource.loop = false;
                playerHitSource.Play();

                timer_02 = 0f;
            }
        }
    }
    public void PowerUpObtained(Vector3 pos)
    {
        if (timer_02 >= maxPowerUpDelay)
        {

            if (powerUpSource != null)
            {
                powerUpSource.pitch = Random.Range(0.8f, 1f);
                powerUpSource.volume = Random.Range(0.8f, 1f);
                powerUpSource.minDistance = 20f;
                powerUpSource.loop = false;
                powerUpSource.Play();

                timer_02 = 0f;
            }
        }
    }
}
