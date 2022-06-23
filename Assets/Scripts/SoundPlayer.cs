using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [Header("Shooting Sound")]
    [SerializeField] private AudioClip shooting;
    [SerializeField] [Range(0, 1)] private float FireVolume;

    [Header("Damage Sound")] [SerializeField]
    private AudioClip damageSound;
    [SerializeField] [Range(0, 1)] private float DamageVolume;
    
    private static SoundPlayer instance;

    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingAudio()
    {
        if (shooting != null)
        {
            AudioSource.PlayClipAtPoint(shooting, Camera.main.transform.position, FireVolume);
        }
    }
    
    public void PlayDamageAudio()
    {
        if (damageSound != null)
        {
            AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position, DamageVolume);
        }
    }

}
