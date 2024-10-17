using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerScript : MonoBehaviour
{
    public static PlayerManagerScript instance;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
