using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private ParticleSystem HitEffect;
    private CameraShake _cameraShake;
    [SerializeField] bool ApplyShake;

    private void Awake()
    {
        _cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHit();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    void PlayHit()
    {
        if (HitEffect != null)
        {
            ParticleSystem instance = Instantiate(HitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    void ShakeCamera()
    {
        if (_cameraShake != null && ApplyShake )
        {
            _cameraShake.Play();
        }
    }

}
