using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lvl1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
