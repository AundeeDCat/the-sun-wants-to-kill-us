using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupDefaults : MonoBehaviour
{
    //game objects deactivated on update
    public GameObject StartMenu, MainMenu, Hovers;

    void Start()
    {
        MainMenu.SetActive(false);
        StartMenu.SetActive(true);
        Hovers.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))//return is enter key not keypadEnter
        {
            StartMenu.SetActive(false);
            MainMenu.SetActive(true);
            Hovers.SetActive(true);
            //SFX
            SoundEffectManager.Play("Tap");
            Time.timeScale = 0;
        }
    }
}
