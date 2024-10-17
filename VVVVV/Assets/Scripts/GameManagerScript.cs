using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    public GameObject player;
    public GameObject UpKiller;
    public GameObject DownKiller;
    public Vector2 endFlagPosition;
    public Vector2 startFlagPosition;
    public bool end = false;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += onSceneLoaded;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        startFlagPosition = GameObject.Find("StartFlag").transform.position;
        player.transform.position = startFlagPosition + new Vector2(1f, 0f);
    }

    void Update()
    {

    }

    void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpKiller = GameObject.Find("UpKiller");
        DownKiller = GameObject.Find("DownKiller");
        UpKiller.GetComponent<Renderer>().enabled = false;
        DownKiller.GetComponent<Renderer>().enabled = false;
        if (end)
        {
            endFlagPosition = GameObject.Find("EndFlag").transform.position;
            startFlagPosition = GameObject.Find("StartFlag").transform.position;
            player.transform.position = startFlagPosition + new Vector2(1f, 0f);
        }
        else
        {
            startFlagPosition = GameObject.Find("StartFlag").transform.position;
            endFlagPosition = GameObject.Find("EndFlag").transform.position;
            player.transform.position = endFlagPosition + new Vector2(-1f, 0f);
        }
    }
}
