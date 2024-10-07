using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagBehavior : MonoBehaviour
{
    [SerializeField] public bool IsStartFlag;
    [SerializeField] public bool IsEndFlag;
    public GameObject player;

    private GameManagerScript gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManagerScript>();
    }

    public void ChangeScenes()
    {
        if (IsStartFlag)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else if (IsEndFlag)
        {
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
