using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject LaserPrefab;
    [SerializeField] private float LaserSpeed = 10f;
    [SerializeField] private float LaserLifeTime = 5f;

    public bool isFiring;
}
