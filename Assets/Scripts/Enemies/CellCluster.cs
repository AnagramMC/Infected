using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCluster : MonoBehaviour
{

    public RedBloodCell[] Cells;
    private int[] numberArr;

    public PlayerHealth target;


    private int numofCells;
    private int cellCount = 0;
    private bool hasAttacked = false;

	// Use this for initialization
	void Awake ()
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

        target = FindObjectOfType<PlayerHealth>();
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
        if (!target.dead)
        {
            if (Cells[numberArr[cellCount]].gameObject.activeSelf == true)
            {
                Cells[numberArr[cellCount]].Attack();

                cellCount++;
                if (cellCount >= numofCells)
                {
                    cellCount = 0;
                  // Restart();
                }
                else
                {
                    StartAttack();
                }
            }
            else
            {
                
                cellCount++;

                if (cellCount >= numofCells)
                {
                    cellCount = 0;
                    //Restart();
                }
                else
                {
                   
                    FireCell();
                }

            }
        }
        else
        {
            StartCoroutine(LaunchWait(1));
        }


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

    public void Restart()
    {
       GameObject poolObject = GameObject.FindGameObjectWithTag("RedBloodPool");
       ObjectPool poolScript = poolObject.GetComponent<ObjectPool>();

       gameObject.SetActive(false);

       poolScript.PlaceObject(this.gameObject);

        hasAttacked = false;

    }

    public void TurnCellsOn()
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            Cells[i].ReturnPosition();
            Cells[i].gameObject.SetActive(true);
           
        }
        
    }

    public void CellCheck()
    {
       
        int deadCounter = 0;
        for (int i = 0; i < Cells.Length; i++)
        {
            if(Cells[i].gameObject.activeSelf == false)
            {
                deadCounter++;
            }
        }

        if(deadCounter >= Cells.Length)
        {
            Restart();
        }
    }

  

    
}
