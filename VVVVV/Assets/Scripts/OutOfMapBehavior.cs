using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfMapBehavior : MonoBehaviour
{
    public GameObject player;
    public Vector2 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameManagerScript.instance.startFlagPosition + new Vector2(1f, 0f);
        player = PlayerManagerScript.instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

                player.transform.position = spawnPoint;
                player.GetComponent<PlayerMovement>().isGravityFlipped = false;
                if (player.transform.localScale.y < 0)
                {
                    player.transform.localScale = new Vector2(-1, transform.localScale.y);
                }
                else
                {
                    player.transform.localScale = new Vector2(1, transform.localScale.y);
                }
        }
    }

}
