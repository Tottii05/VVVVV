using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject GameManager;

    private void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }
    public void PlayMethod()
    {
        GameManager.GetComponent<GameManagerScript>().end = true;
        SceneManager.LoadScene("Lvl1");
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitMethod()
    {
        Application.Quit();
    }
}
