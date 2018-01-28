using System.Collections;
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
    private int curTotalSpawn=1;
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
        if(curObject.name.Contains("Pickup"))
        {
            Instantiate(curObject, spawnLocation, Quaternion.identity);
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

               if(curObject.GetComponent<CellCluster>())
                 {
                   Debug.Log("USED");
                   curObject.GetComponent<CellCluster>().TurnCellsOn();
                 }
            }
        }

        StartCoroutine(countdownToNextSpawn());
    }

    IEnumerator countdownToNextSpawn()
    {
        curSpawnNumber--;
        if(curSpawnNumber>50)
        {
            if(!doOnce)
            {
                waitForNextSpawn++;
                doOnce = true;
            }
            
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
