using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public bool isGravityFlipped = false;
    private float gravityForce = 12f;
    private float speedForce = 15f;
    private bool grounded = false;
    private bool dead = false;
    private Animator playerAnimator;
    public Rigidbody2D rb;
    void Start()
    {
        isGravityFlipped = false;
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        ApplyCustomGravity();
        CheckGrounded();
    }

    public void Move()
    {
        if (!dead)
        {
            float horizontal = Input.GetAxis("Horizontal");
            GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal * speedForce, GetComponent<Rigidbody2D>().velocity.y);
            MirrorSpriteHorizontal();
            RunAnimation();
            JumpNChangeGravity();
        }
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
        GetComponent<Animator>().SetBool("IsRunning", Input.GetAxis("Horizontal") != 0);
    }

    public void JumpNChangeGravity()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
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

    public void CheckGrounded()
    {
        grounded = false;
        Vector2 direction = isGravityFlipped ? Vector2.up : Vector2.down;
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position + new Vector3(-0.4f, 0), direction, 1.1f);
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position + new Vector3(0.3f, 0), direction, 1.1f);
        if(leftHit.collider != null)
        {
            if (leftHit.collider.gameObject.layer == 8 && rightHit.collider.gameObject.layer == 8)
            {
                grounded = leftHit.collider != null || rightHit.collider != null;
            }
        }
    }
    private void Respawn()
    {
        if (isGravityFlipped) {
            isGravityFlipped = false;
            transform.localScale = new Vector2(transform.localScale.x, -transform.localScale.y);
        }
        transform.position = GameManagerScript.instance.startFlagPosition + new Vector2(1f, 0f);
        dead = false;
        //rb.constraints = RigidbodyConstraints2D.None;
    }
    IEnumerator KillCoroutine()
    {
        playerAnimator.SetBool("IsDead", true);
        dead = true;
        yield return new WaitForSeconds(0.05f);
        playerAnimator.SetBool("IsDead", false);
        yield return new WaitForSeconds(0.1f);
        Respawn();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Killer")
        {
            StartCoroutine(KillCoroutine());
        }
    }
}
