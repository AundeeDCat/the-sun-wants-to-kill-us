using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsOption : MonoBehaviour
{

    public TextMeshProUGUI choice0, choice1, choice2, choice3;
    public GameObject Arrow0, Arrow1, Arrow2, Arrow3, Main, settingsTab, SFX, BGM;
    private int Options = 4;
    private int selectedOpt;


    void Start()
    {
        //initialization: check!
        /*Copy of RGBA Colors
        Lime Yellow: 255, 253, 137
        Yellow Green: 200,236,115
         */
        selectedOpt = 1;
        choice0.color = new Color32(255, 253, 137, 255);
        choice1.color = new Color32(255, 253, 137, 255);
        choice2.color = new Color32(200, 236, 115, 120);
        choice3.color = new Color32(200, 236, 115, 120);
        Arrow0.SetActive(true);
        Arrow1.SetActive(false);
        Arrow2.SetActive(false);
        Arrow3.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            SoundEffectManager.Play("Up");
            InputKeysUp();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SoundEffectManager.Play("Down");
            InputKeysDown();
        }
        if (Input.GetKeyDown(KeyCode.Return)){
            SoundEffectManager.Play("Tap");
            InputKeysEnter();
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            Main.SetActive(true);
            Arrow2.SetActive(true);
            settingsTab.SetActive(false);
            gameObject.GetComponent<SettingsOption>().enabled = false;
            gameObject.GetComponent<UIChoices>().enabled = true;
            if(SFX.activeSelf)
            {
                SFX.SetActive(false);
            }
            if (BGM.activeSelf)
            {
                BGM.SetActive(false);
            }
        }
    }

    public void InputKeysUp()
    {
        //Input W :Check!
        selectedOpt += 1;
        if (selectedOpt > Options)
        {
            selectedOpt = 1;
        }
        choice0.color = new Color32(200, 236, 115, 120);
        choice1.color = new Color32(200, 236, 115, 120);
        choice2.color = new Color32(200, 236, 115, 120);
        choice3.color = new Color32(200, 236, 115, 120);
        switch (selectedOpt)
        {
            case 0:
                choice0.color = new Color32(255, 253, 137, 255);
                Arrow0.SetActive(true);
                Arrow1.SetActive(false);
                Arrow2.SetActive(false);
                Arrow3.SetActive(false);
                break;
            case 1:
                choice1.color = new Color32(255, 253, 137, 255);
                Arrow0.SetActive(false);
                Arrow1.SetActive(true);
                Arrow2.SetActive(false);
                Arrow3.SetActive(false);
                break;
            case 2:
                choice2.color = new Color32(255, 253, 137, 255);
                Arrow0.SetActive(false);
                Arrow1.SetActive(false);
                Arrow2.SetActive(true);
                Arrow3.SetActive(false);
                break;
            case 3:
                choice3.color = new Color32(255, 253, 137, 255);
                Arrow0.SetActive(false);
                Arrow1.SetActive(false);
                Arrow2.SetActive(false);
                Arrow3.SetActive(true);
                break;
        }
    }

    public void InputKeysDown()
    {
        selectedOpt -= 1;
        if (selectedOpt < 1) //If at end of list go back to top
        {
            selectedOpt = Options;
        }
        choice0.color = new Color32(200, 236, 115, 120);
        choice1.color = new Color32(200, 236, 115, 120);
        choice2.color = new Color32(200, 236, 115, 120);
        choice3.color = new Color32(200, 236, 115, 120);
        switch (selectedOpt)
        {
            case 0:
                choice0.color = new Color32(255, 253, 137, 255);
                Arrow0.SetActive(true);
                Arrow1.SetActive(false);
                Arrow2.SetActive(false);
                Arrow3.SetActive(false);
                break;
            case 1:
                choice1.color = new Color32(255, 253, 137, 255);
                Arrow0.SetActive(false);
                Arrow1.SetActive(true);
                Arrow2.SetActive(false);
                Arrow3.SetActive(false);
                break;
            case 2:
                choice2.color = new Color32(255, 253, 137, 255);
                Arrow0.SetActive(false);
                Arrow1.SetActive(false);
                Arrow2.SetActive(true);
                Arrow3.SetActive(false);
                break;
            case 3:
                choice3.color = new Color32(255, 253, 137, 255);
                Arrow0.SetActive(false);
                Arrow1.SetActive(false);
                Arrow2.SetActive(false);
                Arrow3.SetActive(true);
                break;
        }
    }

    public void InputKeysEnter()
    {
        switch (selectedOpt)
        {
            case 0:
                SceneManager.LoadScene("Credit Page Scene");
                break;
            case 1:
                BGM.SetActive(true);
                SFX.SetActive(false);
                break;
            case 2:
                BGM.SetActive(false);
                SFX.SetActive(true);
                break;
            case 3:
                Main.SetActive(true);
                Arrow2.SetActive(true);
                settingsTab.SetActive(false);
                gameObject.GetComponent<UIChoices>().enabled = true;
                gameObject.GetComponent<SettingsOption>().enabled = false;
                break;
        }
    }
}
