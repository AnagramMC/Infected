﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    /*
     White cell -5
     red cell - 9
     medicine type 1 - 10
     medicine type 2 - 3
         
         */
    // Here's where we define our weighted object structure,
    // and flag it Serializable so it can be edited in the Inspector.
    [System.Serializable]
    public struct Spawnable
    {
        public GameObject gameObject;
        public float weight;
    }

    // Now expose an array of these to be populated in the Inspector.
    public Spawnable[] spawnList;
    private AudioController audioScript;
    // Track the total weight used in the whole array.
    float _totalSpawnWeight;
    private ObjectPool gameObjectPool;
    private GameObject curObject;
    private Vector2 spawnLocation;
    public int curSpawnNumber=10;
    public int curTotalSpawn=1;
    public float waitForNextSpawn = 0.5f;
    public float waitForNextDifficulty = 1f;
    private float difficultyMultiplier=0.1f;
    public GameObject[] spawnRange;
    private float minX;
    private float maxX;
    private float defaultY;
    private bool doOnce;
    Quaternion tempRot;
    // Update the total weight when the user modifies Inspector properties,
    // and on initialization at runtime.
    void OnValidate()
    {
        _totalSpawnWeight = 0f;
        foreach (var spawnable in spawnList)
            _totalSpawnWeight += spawnable.weight;
    }

    // As Problematic points out below, OnValidate isn't called
    // in a built executable. But in that case we don't need to react
    // to a user fiddling with the Inspector mid-game, so it suffices
    // to run this code once during Awake:
    void Awake()
    {
        minX = spawnRange[0].transform.position.x;
        maxX = spawnRange[1].transform.position.x;
        defaultY = transform.position.y;
        audioScript = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
        OnValidate();
    }

    private void Start()
    {
        Spawn();
        if(audioScript)
        {
            audioScript.BackgroundMusic();
        }
    }
    // Spawn an item randomly, according to the relative weights.
    public void Spawn()
    {
        // Generate a random position in the list.
        float pick = Random.value * _totalSpawnWeight;
        int chosenIndex = 0;
        float cumulativeWeight = spawnList[0].weight;
        // Step through the list until we've accumulated more weight than this.
        // The length check is for safety in case rounding errors accumulate.
        while (pick > cumulativeWeight && chosenIndex < spawnList.Length - 1)
        {
            chosenIndex++;
            cumulativeWeight += spawnList[chosenIndex].weight;
        }
        //determine spawn location
        spawnLocation.x = Random.Range(minX, maxX);
        spawnLocation.y = defaultY;
        GameObject curObject = spawnList[chosenIndex].gameObject;
        if(curObject.name.Contains("PickUp"))
        {
            Instantiate(curObject, spawnLocation, Quaternion.identity);
            curSpawnNumber -= Mathf.RoundToInt(cumulativeWeight);

        }
        else
        {
            //get pool from current chosen index
            gameObjectPool = curObject.GetComponent<ObjectPool>();
            if(gameObjectPool)
            {
                //get current object from pool
                curObject = gameObjectPool.GetObject();
                //set current object position
                curObject.transform.position = spawnLocation;
                //set current object active
                curObject.SetActive(true);
                curSpawnNumber -= Mathf.RoundToInt(cumulativeWeight);

                if (curObject.GetComponent<CellCluster>())
                 {
                   curObject.GetComponent<CellCluster>().TurnCellsOn();
                 }
            }
        }
        StartCoroutine(countdownToNextSpawn());
    }

    IEnumerator countdownToNextSpawn()
    {
        if (curTotalSpawn > 2500)
        {
            waitForNextSpawn = 0.3f;
        }
        if (curTotalSpawn > 2000)
        {
            waitForNextSpawn = 0.35f;
        }
        if (curTotalSpawn > 1700)
        {
            waitForNextSpawn = 0.4f;
        }
        else if (curTotalSpawn > 1500)
        {
            waitForNextSpawn = 0.5f;
        }
        else if (curTotalSpawn > 1200)
        {
            waitForNextSpawn = 0.6f;
        }
        else if (curTotalSpawn > 1000)
        {
            waitForNextSpawn = 0.65f;
        }
        else if (curTotalSpawn > 400)
        {
            waitForNextSpawn = 0.75f;
        }
        else if (curTotalSpawn > 200)
        {
            waitForNextSpawn = 0.85f;
        }
        else if(curTotalSpawn>100)
        {
            waitForNextSpawn = 0.9f;
        }
        yield return new WaitForSeconds(waitForNextSpawn);
        if(curSpawnNumber>0)
        {
            Spawn();
        }
        else
        {
            difficultyMultiplier++;
            curTotalSpawn +=Mathf.RoundToInt( curTotalSpawn * difficultyMultiplier);
            curSpawnNumber += curTotalSpawn;
            
            StartCoroutine(countdownToIncreaseDifficulty());
        }
    }
    IEnumerator longerCountdownToSpawn()
    {
        yield return new WaitForSeconds(3);
        if (curSpawnNumber > 0)
        {
            Spawn();
        }
    }
    public void ClearAllCurrentEnemies()
    {
        for(int i=0;i<=spawnList.Length-1;i++)
        {
            GameObject thisObject = spawnList[i].gameObject;
            if(!thisObject.name.Contains("PickUp"))
            {
                ObjectPool curPool = thisObject.GetComponent<ObjectPool>();
                curPool.ReturnAllObjects();
            }
        }
        
        StopCoroutine(countdownToNextSpawn());
        StartCoroutine(longerCountdownToSpawn());
    }

   

    IEnumerator countdownToIncreaseDifficulty()
    {
        yield return new WaitForSeconds(waitForNextDifficulty);
        Spawn();
    }

}
