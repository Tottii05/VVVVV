using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private const float Speed = 5.0f;
    public Vector2 spawnPoint;
    public CannonBehavior cannon;
    private SpriteRenderer sp;
    private float timeToDestroy = 5.0f;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        spawnPoint = GameManagerScript.instance.startFlagPosition + new Vector2(1f, 0f);
    }
    void Update()
    {
        Move();
        LifeTimeChecker();
    }

    public void Move()
    {
        transform.Translate(new Vector3(-Speed * Time.deltaTime, 0, 0));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        cannon.Push(gameObject);
    }

    public void LifeTimeChecker()
    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
        {
            cannon.Push(gameObject);
        }
    }
}
