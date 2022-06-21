using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [Header("Shooting Sound")]
    [SerializeField] private AudioClip shooting;
    [SerializeField] [Range(0, 1)] private float FireVolume;

    [Header("Damage Sound")] [SerializeField]
    private AudioClip damageSound;
    [SerializeField] [Range(0, 1)] private float DamageVolume;
    
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
