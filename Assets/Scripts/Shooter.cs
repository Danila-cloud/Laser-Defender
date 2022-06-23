using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject LaserPrefab;
    [SerializeField] private float LaserSpeed = 10f;
    [SerializeField] private float LaserLifeTime = 5f;
    private float firingRate = 0.2f;
    [SerializeField ] private bool UseAI;

    [SerializeField] public bool isFiring;

    private Coroutine fireCoroutine;
    private SoundPlayer _soundPlayer;

    private void Awake()
    {
        _soundPlayer = FindObjectOfType<SoundPlayer>();
    }

    private void Start()
    {
        if (UseAI == true)
        {
            firingRate = Random.Range(0.5f, 1.5f);
            isFiring = true;
            
        }
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinue());
        }
        else if(!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinue()
    {
        while (true)
        {
            GameObject instance = Instantiate(LaserPrefab, transform.position, Quaternion.identity);
            Destroy(instance, LaserLifeTime);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * LaserSpeed;
            }
            _soundPlayer.PlayShootingAudio();

            yield return new WaitForSeconds(firingRate);
        }
    }
}
