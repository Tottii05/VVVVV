using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Vector2 SpawnPosition;
    private float patrolDistance = 6f;
    private float speed = -2f;
    private Vector2 targetPosition;
    private bool movingLeft = true;
    public GameObject player;
    public Vector2 spawnPoint;
    private Animator playerAnimator;

    void Start()
    {
        spawnPoint = GameManagerScript.instance.startFlagPosition + new Vector2(1f, 0f);
        SpawnPosition = transform.position;
        targetPosition = SpawnPosition + new Vector2(-patrolDistance, 0);
        player = GameObject.Find("Player");
        playerAnimator = player.GetComponent<Animator>();
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(KillCoroutine());
        }
    }
    private void Respawn()
    {
        player.transform.position = spawnPoint + new Vector2();
    }
    IEnumerator KillCoroutine()
    {
        playerAnimator.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.05f);
        playerAnimator.SetBool("IsDead", false);
        yield return new WaitForSeconds(0.1f);
        Respawn();
    }
}
