using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupDefaults : MonoBehaviour
{
    //game objects deactivated on update
    public GameObject StartMenu, MainMenu;

    void Start()
    {
        MainMenu.SetActive(false);
        StartMenu.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            StartMenu.SetActive(false);
            MainMenu.SetActive(true);
        }
    }
}
