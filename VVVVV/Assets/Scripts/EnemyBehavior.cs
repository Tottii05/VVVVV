using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBehavior : MonoBehaviour
{
    private Vector2 SpawnPosition;
    private float speed = -2f;
    public GameObject player;
    private Rigidbody2D _rb;
    private bool disabled = false;

    void Start()
    {
        SpawnPosition = transform.position;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Patrol();
    }

    public void Patrol()
    {
        //transform.position = Vector2.MoveTowards(transform.position, transform.right, -speed * Time.deltaTime);
        _rb.velocity = transform.right * transform.localScale.x * speed;
        UpdateTargetPosition();
    }

    private void UpdateTargetPosition()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -1* transform.localScale.x*  transform.right+ -0.5f* transform.up, 2f);
        Debug.DrawRay(transform.position, transform.localScale.x *-1* transform.right + -0.5f * transform.up, Color.red);
        if (hit.collider == null && !disabled)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
            disabled = true;
        }
        else
        {
            Debug.Log(hit.collider.gameObject.name);
            disabled = false;
        }
    }
}
