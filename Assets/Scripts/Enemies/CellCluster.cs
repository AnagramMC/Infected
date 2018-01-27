using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCluster : MonoBehaviour
{

    public RedBloodCell[] Cells;
    private int[] numberArr;
    



    private int numofCells;
    private int cellCount = 0;

	// Use this for initialization
	void Start ()
    {
        numofCells = Cells.Length;

        numberArr = new int[numofCells];

        for (int i = 0; i < Cells.Length; i ++)
        {
            numberArr[i] = i;
        }

        for (int i = 0; i < numberArr.Length; i++)
        {
            int temp = numberArr[i];
            int randomIndex = Random.Range(i, numberArr.Length);
            numberArr[i] = numberArr[randomIndex];
            numberArr[randomIndex] = temp;
        }

        for (int i = 0; i < numberArr.Length; i++)
        {
            Debug.Log(numberArr[i]);
        }

            StartAttack();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void StartAttack()
    {
        StartCoroutine(SendThem(1));
    }

    IEnumerator SendThem(int seconds)
    {
        
        yield return new WaitForSeconds(seconds);
        Debug.Log("Attacking!");
        if (Cells[cellCount])
        {
            Cells[numberArr[cellCount]].Attack();
        }
        cellCount++;
        if (cellCount >= numofCells)
        {
            cellCount = 0;
        }
        else
        {
            StartAttack();
        }
    }
}
