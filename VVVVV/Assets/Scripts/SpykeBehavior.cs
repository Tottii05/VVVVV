using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpykeBehavior : MonoBehaviour
{
    public GameObject player;
    public Vector2 spawnPoint;
    private Animator playerAnimator;

    void Start()
    {
        spawnPoint = GameManagerScript.instance.startFlagPosition + new Vector2(1f, 0f);
        player = GameObject.Find("Player");
        playerAnimator = player.GetComponent<Animator>();
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
        player.transform.position = spawnPoint;
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
