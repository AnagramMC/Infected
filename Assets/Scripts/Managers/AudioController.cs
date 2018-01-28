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

    [Header("Enemy Hit")]
    public AudioSource EnemyHitSource;
    public float EnemyhitDelay;
    public float maxEnemyHitDelay;


    [Header("PowerUp")]
    public AudioSource powerUpSource;
    public float powerUpDelay;
    public float maxPowerUpDelay;

    [Header("MedicineExplosion")]
    public AudioSource MedExplosionSource;
    public float MedExplosionDelay;
    public float maxMedExplosionDelay;


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
                BgMusicSource.priority = 100;
                BgMusicSource.volume = 0.5f;
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
                GameOverSource.priority = 100;
                GameOverSource.volume = 0.5f;
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
                playerHitSource.volume = Random.Range(0.4f, 0.5f);
                playerHitSource.minDistance = 20f;
                playerHitSource.loop = false;
                playerHitSource.Play();

                timer_02 = 0f;
            }
        }
    }
    public void EnemyHit(Vector3 pos)
    {
        if (timer_02 >= maxEnemyHitDelay)
        {

            if (EnemyHitSource != null)
            {
                EnemyHitSource.pitch = Random.Range(0.8f, 1f);
                EnemyHitSource.volume = Random.Range(0.4f, 0.5f);
                EnemyHitSource.minDistance = 20f;
                EnemyHitSource.loop = false;
                EnemyHitSource.Play();

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
                powerUpSource.volume = Random.Range(0.2f, 0.5f);
                powerUpSource.minDistance = 20f;
                powerUpSource.loop = false;
                powerUpSource.Play();

                timer_02 = 0f;
            }
        }
    }
    public void MedicineExplosion(Vector3 pos)
    {
        if (timer_02 >= maxMedExplosionDelay)
        {

            if (MedExplosionSource != null)
            {
                MedExplosionSource.pitch = Random.Range(0.5f, 0.8f);
                MedExplosionSource.volume = Random.Range(0.2f, 0.5f);
                MedExplosionSource.minDistance = 20f;
                MedExplosionSource.loop = false;
                MedExplosionSource.Play();

                timer_02 = 0f;
            }
        }
    }
}
