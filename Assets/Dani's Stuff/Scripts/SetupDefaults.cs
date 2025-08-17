using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupDefaults : MonoBehaviour
{
    //game objects deactivated on update
    public GameObject StartMenu, MainMenu, Hovers, SFX, BGM;

    void Start()
    {
        MainMenu.SetActive(false);
        StartMenu.SetActive(true);
        Hovers.SetActive(false); 
        SFX.SetActive(false); 
        BGM.SetActive(false);
        gameObject.GetComponent<UIChoices>().enabled = false;
        gameObject.GetComponent<SettingsOption>().enabled = false;
        MusicManager.Play("Main Menu");
    }

    void Update()
    {
        OnKeyEnter();
    }

    public void OnKeyEnter()
    {
        if (Input.GetKeyDown(KeyCode.Return))//return is enter key not keypadEnter
        {
            StartMenu.SetActive(false);
            MainMenu.SetActive(true);
            Hovers.SetActive(true);
            //SFX
            SoundEffectManager.Play("Tap");
            gameObject.GetComponent<UIChoices>().enabled = true;//MainMenu UI script
        }
    }
}
