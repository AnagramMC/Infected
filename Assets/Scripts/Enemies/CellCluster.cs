using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCluster : MonoBehaviour
{

    public RedBloodCell[] Cells;
    private int[] numberArr;
    



    private int numofCells;
    private int cellCount = 0;
    private bool hasAttacked = false;

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

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void StartAttack()
    {
        StartCoroutine(LaunchWait(1));
    }

    public void FireCell()
    {
        if (Cells[numberArr[cellCount]].gameObject.activeSelf == true)
        {
            Cells[numberArr[cellCount]].Attack();

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
        else
        {
            Debug.Log("DEAD CELL!");
            cellCount++;

            if (cellCount >= numofCells)
            {
                cellCount = 0;
            }
            else
            {
                Debug.Log("Fire CELL!");
                FireCell();
            }

        }

        Debug.Log(cellCount);
    }

    IEnumerator LaunchWait(int seconds)
    {
        
        yield return new WaitForSeconds(seconds);
        FireCell();
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if(!hasAttacked)
            {
                StartAttack();

                hasAttacked = true;
            }
        }
    }
}
