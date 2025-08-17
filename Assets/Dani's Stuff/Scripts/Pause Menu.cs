using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public TextMeshProUGUI choice0, choice1, choice2, choice3, choice4;
    public GameObject Menu, SFX, BGM;
    private int Options = 5;
    private int selectedOpt;
    //pause
    public static bool gameIsPaused;


    void Start()
    {
        //initialization: check!
        /*Copy of RGBA Colors
        Lime Yellow: 255, 253, 137
        Yellow Green: 200,236,115
         */
        selectedOpt = 0;
        choice0.color = new Color32(255, 253, 137, 255);
        choice1.color = new Color32(200, 236, 115, 120);
        choice2.color = new Color32(200, 236, 115, 120);
        choice3.color = new Color32(200, 236, 115, 120);
        choice3.color = new Color32(200, 236, 115, 120);
        SFX.SetActive(false);
        BGM.SetActive(false);
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
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Menu.activeSelf)
            {
                Menu.SetActive(false);
            }
            if (SFX.activeSelf)
            {
                SFX.SetActive(false);
            }
            if (BGM.activeSelf)
            {
                BGM.SetActive(false);
            }
            gameIsPaused = !gameIsPaused;
            SoundEffectManager.Play("Pause");
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            Menu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            Menu.SetActive(false);
        }
    }

    public void InputKeysUp()
    {
        //Input W :Check!
        selectedOpt += 1;
        if (selectedOpt > Options)
        {
            selectedOpt = 0;
        }
        choice0.color = new Color32(200, 236, 115, 120);
        choice1.color = new Color32(200, 236, 115, 120);
        choice2.color = new Color32(200, 236, 115, 120);
        choice3.color = new Color32(200, 236, 115, 120);
        choice4.color = new Color32(200, 236, 115, 120);
        switch (selectedOpt)
        {
            case 0:
                choice0.color = new Color32(255, 253, 137, 255);
                break;
            case 1:
                choice1.color = new Color32(255, 253, 137, 255);
                break;
            case 2:
                choice2.color = new Color32(255, 253, 137, 255);
                break;
            case 3:
                choice3.color = new Color32(255, 253, 137, 255);
                break;
            case 4:
                choice4.color = new Color32(255, 253, 137, 255);
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
        choice4.color = new Color32(200, 236, 115, 120);
        switch (selectedOpt)
        {
            case 0:
                choice0.color = new Color32(255, 253, 137, 255);
                break;
            case 1:
                choice1.color = new Color32(255, 253, 137, 255);
                break;
            case 2:
                choice2.color = new Color32(255, 253, 137, 255);
                break;
            case 3:
                choice3.color = new Color32(255, 253, 137, 255);
                break;
            case 4:
                choice4.color = new Color32(255, 253, 137, 255);
                break;
        }
    }

    public void InputKeysEnter()
    {
        switch (selectedOpt)
        {
            case 0://quit
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                SoundEffectManager.Play("Exit");
                Application.Quit();
                break;
            case 1://menu
                new WaitForSeconds(1);
                SceneManager.LoadScene("Main Menu");
                break;
            case 2://BGM
                BGM.SetActive(true);
                SFX.SetActive(false);
                break;
            case 3://SFX
                BGM.SetActive(false);
                SFX.SetActive(true);
                break;
            case 4://Continue
                Time.timeScale = 1;
                Menu.SetActive(false);
                break;
        }
    }
}
