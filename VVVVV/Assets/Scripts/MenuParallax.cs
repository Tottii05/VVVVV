using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuParallax : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;
    private Vector2 offset;
    private Material material;  

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        offset = transform.localPosition;
    }

    void Update()
    {
        offset = velocity * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
