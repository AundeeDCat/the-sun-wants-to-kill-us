using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class SetupDefaults : MonoBehaviour
{
    //game objects deactivated on update
    public GameObject StartMenu, MainMenu, Hovers, SFX, BGM;
    public SkipEnterMenu Instance;

    public object GameObject { get; internal set; }

    void Update()
    {
        if (Instance.Norepeat == false)
        {
            DontRepeat();
            MusicManager.Play("Main Menu");
        }
        if (Instance.Norepeat == true)
        {
            OnKeyEnter();
        }
        if (Input.GetKeyDown(KeyCode.Return))//return is enter key not keypadEnter
        {
            OnKeyEnter();
        }
    }

    public void OnKeyEnter()
    {
        StartMenu.SetActive(false);
        MainMenu.SetActive(true);
        Hovers.SetActive(true);
        //SFX
        SoundEffectManager.Play("Tap");
        gameObject.GetComponent<UIChoices>().enabled = true;//MainMenu UI script
        Instance.Norepeat = true;
    }

    public void DontRepeat()
    {
            MainMenu.SetActive(false);
            StartMenu.SetActive(true);
            Hovers.SetActive(false);
            SFX.SetActive(false);
            BGM.SetActive(false);
            gameObject.GetComponent<UIChoices>().enabled = false;
            gameObject.GetComponent<SettingsOption>().enabled = false;
    }
}
