using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float ShakeDuration = 1f;
    private float ShakeAmplitude = 0.5f;

    private Vector3 InitialPosition;
    void Start()
    {
        InitialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float ElapsedTime = 0f;
        while (ElapsedTime < ShakeDuration)
        {
            transform.position = InitialPosition + (Vector3)Random.insideUnitCircle * ShakeAmplitude;
            ElapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = InitialPosition;
    }
    
}
