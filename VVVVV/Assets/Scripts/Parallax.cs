using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;
    private Vector2 offset;
    private Rigidbody2D playerRb;
    private Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        offset = (playerRb.velocity.x / 100f) * velocity * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
