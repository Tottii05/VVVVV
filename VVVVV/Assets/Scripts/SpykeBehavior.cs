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
}
