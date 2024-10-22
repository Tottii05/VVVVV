using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private const float Speed = 5.0f;

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(new Vector3(0, -Speed * Time.deltaTime, 0));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.layer != 0)
        {
            Destroy(gameObject);
        }
    }
}
