using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public bool isGravityFlipped = false;
    private float gravityForce = 12f;
    private float speedForce = 15f;
    private bool grounded = false;
    private bool dead = false;
    public bool finalLvl;
    private Animator playerAnimator;
    public AudioManager audioManager;
    void Start()
    {
        isGravityFlipped = false;
        playerAnimator = GetComponent<Animator>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void Update()
    {
        Move();
        ApplyCustomGravity();
        CheckGrounded();
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            finalLvl = true;
        }
        else
        {
            finalLvl = false;
        }
    }

    public void Move()
    {
        if (!dead && !finalLvl)
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
            audioManager.PlaySFX(audioManager.jump);
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
        Vector2 boxCenter = (Vector2)transform.position + direction * 0.1f;
        Vector2 boxSize = new Vector2(0.5f, 0.1f);
        RaycastHit2D hit = Physics2D.BoxCast(boxCenter, boxSize, 0f, direction, 0.5f);
        if (hit.collider != null && hit.collider.gameObject.layer == 8)
        {
            grounded = true;
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
    }
    IEnumerator KillCoroutine()
    {
        playerAnimator.SetBool("IsDead", true);
        dead = true;
        audioManager.PlaySFX(audioManager.death);
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
