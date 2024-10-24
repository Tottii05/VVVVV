using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Vector2 SpawnPosition;
    [SerializeField] private float patrolDistance = 5f;
    private float speed = -2f;
    private Vector2 targetPosition;
    private bool movingLeft = true;
    public GameObject player;

    void Start()
    {
        SpawnPosition = transform.position;
        targetPosition = SpawnPosition + new Vector2(-patrolDistance, 0);
    }

    void Update()
    {
        Patrol();
    }

    public void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, -speed * Time.deltaTime);
        if ((Vector2)transform.position == targetPosition)
        {
            movingLeft = !movingLeft;
            UpdateTargetPosition();
            FlipSprite();
        }
    }

    private void UpdateTargetPosition()
    {
        if (movingLeft)
        {
            targetPosition = SpawnPosition + new Vector2(patrolDistance, 0);
        }
        else
        {
            targetPosition = SpawnPosition - new Vector2(patrolDistance, 0);
        }
    }

    private void FlipSprite()
    {
        if (movingLeft)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
