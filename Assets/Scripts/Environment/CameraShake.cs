using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public float linearIntensity = 0.25f;
    public float angularIntensity = 5f;
    public float screenShakeTime = 0.1f;

    [NonSerialized] public bool isShaking = false;

    private bool angularShaking = true;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isShaking = true;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isShaking = false;
        }
        if (isShaking)
        {
            LinearShaking();
            if (angularShaking)
                AngularShaking();

            StartCoroutine(DisableShake());
        }
    }

    private void LinearShaking()
    {
        Vector2 shake = UnityEngine.Random.insideUnitCircle * linearIntensity;
        Vector3 newPosition = transform.localPosition;
        newPosition.x = shake.x;
        newPosition.y = shake.y;
        transform.localPosition = newPosition;
    }

    private void AngularShaking()
    {
        float shake = UnityEngine.Random.Range(-angularIntensity, angularIntensity);
        transform.localRotation = Quaternion.Euler(0f, 0f, shake);
    }

    public void SetAngularShaking(bool state)
    {
        angularShaking = state;
        if (!angularShaking)
            transform.localRotation = Quaternion.identity;
    }

    public void Enable()
    {
        isShaking = true;
    }

    public void Disable()
    {
        isShaking = false;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    IEnumerator DisableShake()
    {
        yield return new WaitForSeconds(screenShakeTime);
        isShaking = false;
    }
}
