using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagBehavior : MonoBehaviour
{
    private GameManagerScript gameManager;

    void Start()
    {
        gameManager = GameManagerScript.instance;
    }

    public void ChangeScenes()
    {
        if (gameManager != null)
        {
            gameManager.end = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ChangeScenes();
        }
    }
}
