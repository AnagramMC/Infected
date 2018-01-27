using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotRotation : MonoBehaviour {

    private float maxZ=-30f;
    private float minZ = 30f;
    private float degree;
    private float angle;
    private float rotationSpeed;
    private float lerpTempVar;
    private int pivotIndex;
    private bool startTimer;
    private float rotateTimer;
    void Awake()
    {
        degree = minZ;
        rotateTimer = Random.Range(1, 3);
        pivotIndex = 0;
    }
    void Start()
    {
        StartCoroutine(CountdownToSwitch());
        
        startTimer = true;
    }

    void FixedUpdate()
    {
        if(startTimer==false)
        {
            startTimer = true;
            StartCoroutine(CountdownToSwitch());
        }
        //Make a weird rotation speed
        rotationSpeed = rotationSpeed + (lerpTempVar * Time.deltaTime);
        //calculate angle
        angle = Mathf.LerpAngle(transform.rotation.z, degree, Time.time * 0.5f);
        //apply angle to object
        transform.eulerAngles = new Vector3(0, 0, angle);
        
    }

    IEnumerator CountdownToSwitch()
    {
        yield return new WaitForSeconds(rotateTimer);
        rotateTimer = Random.Range(1, 3);
        pivotIndex++;
        if (pivotIndex==1)
        {
            degree = maxZ;
            
        }
        else if(pivotIndex == 2)
        {
            degree = minZ;
            
        }
        else if (pivotIndex == 3)
        {
            degree = 0;
            pivotIndex = 0;
        }
            startTimer = false;

    }
}
