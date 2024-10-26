using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    void Awake()
    {
        if (PauseMenu.instance == null)
        {
            PauseMenu.instance = this;
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
