using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
//code by dani
public class UIChoices : MonoBehaviour
{
    //order of cells in unity, 3-2-1
    public TextMeshProUGUI choice1, choice2, choice3;
    public GameObject Arrow1, Arrow2, Arrow3, Main, settingsTab;

    //private
    private int numOfOptions = 3; //using the switch case
    private int selectedOpt;

    /*Copy of RGBA Colors
        Green: 52, 228, 61
        Dark Green:37,184,100
    */

    void Start()
    {
        //initialization: check!
        selectedOpt = 1;
        choice1.color = new Color32(52, 228, 61, 255);
        choice2.color = new Color32(37, 184, 100, 120);
        choice3.color = new Color32(37, 184, 100, 120);
        Arrow1.SetActive(false);
        Arrow2.SetActive(false);
        Arrow3.SetActive(true);
        settingsTab.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SoundEffectManager.Play("Tap");
            InputKeysEnter();
            new WaitForSeconds(2);
        }
    }

    public void InputKeysUp()
    {
        //Input W :Check!
        selectedOpt += 1;
        if (selectedOpt > numOfOptions)
        {
            selectedOpt = 1;
        }
        choice1.color = new Color32(37, 184, 100, 120);
        choice2.color = new Color32(37, 184, 100, 120);
        choice3.color = new Color32(37, 184, 100, 120);
        switch (selectedOpt) //Set the visual indicator for which option you are on.
        {
            case 1:
                choice1.color = new Color32(52, 228, 61, 255);//RGB indicator, Currently Black
                Arrow1.SetActive(true);
                Arrow2.SetActive(false);
                Arrow3.SetActive(false);
                break;
            case 2:
                choice2.color = new Color32(52, 228, 61, 255);
                Arrow1.SetActive(false);
                Arrow2.SetActive(true);
                Arrow3.SetActive(false);
                break;
            case 3:
                choice3.color = new Color32(52, 228, 61, 255);
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
            selectedOpt = numOfOptions;
        }
        choice1.color = new Color32(37, 184, 100, 120);
        choice2.color = new Color32(37, 184, 100, 120);
        choice3.color = new Color32(37, 184, 100, 120);

        switch (selectedOpt)
        {
            case 1:
                choice1.color = new Color32(52, 228, 61, 255);
                Arrow1.SetActive(true);
                Arrow2.SetActive(false);
                Arrow3.SetActive(false);
                break;
            case 2:
                choice2.color = new Color32(52, 228, 61, 255);
                Arrow1.SetActive(false);
                Arrow2.SetActive(true);
                Arrow3.SetActive(false);
                break;
            case 3:
                choice3.color = new Color32(52, 228, 61, 255);
                Arrow1.SetActive(false);
                Arrow2.SetActive(false);
                Arrow3.SetActive(true);
                break;
        }
    }
    public void InputKeysEnter()
    {
        //switch text color to yellow
        
        switch(selectedOpt){
            case 1:
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                SoundEffectManager.Play("Exit");
                Application.Quit();
                break;
            case 2:
                Main.SetActive(false);
                Arrow2.SetActive(false);
                settingsTab.SetActive(true);
                gameObject.GetComponent<SettingsOption>().enabled = true;//Activates script
                gameObject.GetComponent<UIChoices>().enabled = false;
                break;
            case 3:
                //fade wait for one second
                new WaitForSeconds(1);
                SceneManager.LoadScene("SampleScene");
                gameObject.GetComponent<UIChoices>().enabled = false;
                gameObject.GetComponent<SettingsOption>().enabled = false;
                break;
        }
    }
}
