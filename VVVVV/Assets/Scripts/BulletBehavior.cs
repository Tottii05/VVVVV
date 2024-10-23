using System.Collections;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private const float Speed = 5.0f;
    private Animator playerAnimator;
    public GameObject player;
    public Vector2 spawnPoint;

    void Start()
    {
        spawnPoint = GameManagerScript.instance.startFlagPosition + new Vector2(1f, 0f);
        player = GameObject.Find("Player");
        playerAnimator = player.GetComponent<Animator>();
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
        if (collision.gameObject.tag != "Cannon")
        {
            GameObject cannon = GameObject.Find("Cannon");
            cannon.GetComponent<CannonBehavior>().Push(gameObject);
        }
    }
}
