using System.Collections;
using UnityEditor.UIElements;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private const float Speed = 5.0f;
    public Vector2 spawnPoint;
    public CannonBehavior cannon;
    private SpriteRenderer sp;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
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
        if (collision.gameObject.name == "LayerTrigger")
        {
            ChangeOrderInLayer(-1);
        }
        else
        {
            cannon.Push(gameObject);
        }
    }
    public void ChangeOrderInLayer(int newOrder)
    {
        if (sp != null)
        {
            sp.sortingOrder = newOrder;
            Debug.Log("Order in Layer cambiado a: " + newOrder);
        }
        else
        {
            Debug.LogWarning("No se encontró un componente SpriteRenderer en este objeto.");
        }
    }
}
