using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool isGravityFlipped = false;
    private float gravityForce = 12f;
    private float speedForce = 15f;

    // Start is called before the first frame update
    void Start()
    {
        isGravityFlipped = false;
    }
    private void Update()
    {
        Move();
        ApplyCustomGravity();
    }

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal * speedForce, GetComponent<Rigidbody2D>().velocity.y);
        MirrorSpriteHorizontal();
        RunAnimation();
        JumpNChangeGravity();
    }

    public void MirrorSpriteHorizontal()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
    }

    public void RunAnimation()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
    }

    public void JumpNChangeGravity()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGravityFlipped = !isGravityFlipped;
            transform.localScale = new Vector2(transform.localScale.x, -transform.localScale.y);
        }
    }
    public void ApplyCustomGravity()
    {
        float force = isGravityFlipped ? gravityForce : -gravityForce;
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, force);
    }
}
