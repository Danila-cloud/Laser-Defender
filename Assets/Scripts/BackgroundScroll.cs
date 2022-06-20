using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private Vector2 MoveSpeed;
    private Material _material;
    private Vector2 offset;
    void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset = MoveSpeed * Time.deltaTime;
        _material.mainTextureOffset += offset;
    }
}
