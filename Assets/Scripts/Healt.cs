using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{
    [SerializeField] private int health = 50;


    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer _damageDealer = GetComponent<DamageDealer>();
        if (_damageDealer != null)
        {
            TakeDamage(_damageDealer.GetDamage());
            _damageDealer.Hit();
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
}
