using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] private int ScoreAdd = 50;
    [SerializeField] private int health = 50;
    [SerializeField] private ParticleSystem HitEffect;
    private CameraShake _cameraShake;
    [SerializeField] bool ApplyShake;
    private SoundPlayer _soundPlayer;
    private ScoreKeeping _scoreKeeping;
    private LevelManager _levelManager;
    public int GetHealth()
    {
        return health;
    }
    private void Awake()
    {
        _soundPlayer = FindObjectOfType<SoundPlayer>();
        _cameraShake = Camera.main.GetComponent<CameraShake>();
        _scoreKeeping = FindObjectOfType<ScoreKeeping>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHit();
            _soundPlayer.PlayDamageAudio();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health == 0)
        {
            if (!isPlayer)
            {
                _scoreKeeping.ModifyScore(ScoreAdd);
            }
            else
            {
                _levelManager.LoadEndMenu();
            }
            Destroy(gameObject);
        }
        Debug.Log(health);
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
