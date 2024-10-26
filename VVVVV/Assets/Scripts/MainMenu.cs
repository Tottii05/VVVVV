
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas controllersCanvas;
    [SerializeField] Canvas mainCanvas;
    public AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioManager.PlayMusic(audioManager.menuMusic);
    }
    public void Update()
    {
        HideControllers();
    }
    public void Play()
    {
        audioManager.StopMusic();
        SceneManager.LoadScene("Lvl1");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ShowControlls()
    {
        mainCanvas.gameObject.SetActive(false);
        controllersCanvas.gameObject.SetActive(true);
    }

    public void HideControllers()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            controllersCanvas.gameObject.SetActive(false);
            mainCanvas.gameObject.SetActive(true);
        }
    }
}
