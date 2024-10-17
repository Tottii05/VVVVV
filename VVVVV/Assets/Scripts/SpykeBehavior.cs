using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpykeBehavior : MonoBehaviour
{
    public GameObject player;
    public Vector2 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameManagerScript.instance.startFlagPosition + new Vector2(1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(KillCoroutine());
        }
    }

    IEnumerator KillCoroutine()
    {
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(0.60f);
        player.GetComponent<Renderer>().enabled = true;
        player.transform.position = spawnPoint;
    }
}
