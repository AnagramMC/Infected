using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int size;

    List<GameObject> objectList;


	// Use this for initialization
	void Awake ()
    {
        // Initializes the List of Game Objects
        InitializeList();
	}
	
    void InitializeList()
    {
        // Create new Game objext list
        objectList = new List<GameObject>();

        // Spawn in Game Objects to pool and add to the object list
        for (int i = 0; i < size; i++)
        {
            GameObject gameObj = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;

            gameObj.transform.parent = gameObject.transform;

            gameObj.SetActive(false);

            objectList.Add(gameObj);
        }
    }

    public GameObject GetObject()
    {
        // Check if there are any Game Objects in list
        if(objectList.Count > 0)
        {
            // go to first object in list and remove it
            GameObject gameObj = objectList[0];
            objectList.RemoveAt(0);

            // Return Game Object to specifc manager
            return gameObj;
        }
        else
        {
            // If there is no object currently in list, spawn a new object in to increase the list
            GameObject gameObj = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;

            // Return the spawned in object to specifc manager
            return gameObj;
        }
    }

    public void PlaceObject(GameObject gameObj)
    {
        // Add object back to list and remove it back to pools location
        objectList.Add(gameObj);
        gameObj.transform.position = transform.position;
        
    }
}
