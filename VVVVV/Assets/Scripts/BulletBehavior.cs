using System.Collections;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private const float Speed = 5.0f;
    public Vector2 spawnPoint;
    public CannonBehavior cannon;

    void Start()
    {
        spawnPoint = GameManagerScript.instance.startFlagPosition + new Vector2(1f, 0f);
    }
    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(new Vector3(-Speed * Time.deltaTime, 0, 0));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        cannon.Push(gameObject);
    }
}
