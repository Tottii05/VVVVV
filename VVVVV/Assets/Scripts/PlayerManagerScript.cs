
using UnityEngine;

public class PlayerManagerScript : MonoBehaviour
{
    public static PlayerManagerScript instance;

    public void Awake()
    {
        if (PlayerManagerScript.instance == null)
        {
            PlayerManagerScript.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
