using TMPro;
using UnityEngine;
//code by dani
public class UIChoices : MonoBehaviour
{
    //order of cells in unity, 3-2-1

    public TextMeshProUGUI choice1, choice2, choice3;
    public GameObject Arrow1, Arrow2, Arrow3;
    private int numOfOptions = 3; //using the switch case
    private int selectedOpt;
    void Start()
    {
        //initialization: check!
        selectedOpt = 1;
        choice1.color = new Color32(255, 255, 255, 255);
        choice2.color = new Color32(0, 0, 0, 255);
        choice3.color = new Color32(0, 0, 0, 255);
        //GameObjects true
        Arrow1.SetActive(true);
        //GameObjects false
        Arrow2.SetActive(false);
        Arrow3.SetActive(false);
    }

    void Update()
    {
        InputKeys();
    }

    public void InputKeys()
    {
        //Input W :Check!
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up up, its out moment, charottt");//Comment if no issues;
            SoundEffectManager.Play("Up");
            Time.timeScale = 0;
            selectedOpt += 1;
            if (selectedOpt > numOfOptions)
            {
                selectedOpt = 1;
            }
            choice1.color = new Color32(0, 0, 0, 255);
            choice2.color = new Color32(0, 0, 0, 255);
            choice3.color = new Color32(0, 0, 0, 255);
            switch (selectedOpt) //Set the visual indicator for which option you are on.
            {
                case 1:
                    choice1.color = new Color32(255, 255, 255, 255);//RGB indicator, Currently Black
                    Arrow1.SetActive(true);
                    Arrow2.SetActive(false);
                    Arrow3.SetActive(false);
                    break;
                case 2:
                    choice2.color = new Color32(255, 255, 255, 255);
                    Arrow1.SetActive(false);
                    Arrow2.SetActive(true);
                    Arrow3.SetActive(false);
                    break;
                case 3:
                    choice3.color = new Color32(255, 255, 255, 255);
                    Arrow1.SetActive(false);
                    Arrow2.SetActive(false);
                    Arrow3.SetActive(true);
                    break;
            }
        }
        //Input S:
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Bro Stop Spamming");
            SoundEffectManager.Play("Down");
            Time.timeScale = 0;
            selectedOpt -= 1;
            if (selectedOpt < 1) //If at end of list go back to top
            {
                selectedOpt = numOfOptions;
            }

            choice1.color = new Color32(0, 0, 0, 255); //Use RGB indicator
            choice2.color = new Color32(0, 0, 0, 255);
            choice3.color = new Color32(0, 0, 0, 255);

            switch (selectedOpt)
            {
                case 1:
                    choice1.color = new Color32(255, 255, 255, 255);
                    Arrow1.SetActive(true);
                    Arrow2.SetActive(false);
                    Arrow3.SetActive(false);
                    break;
                case 2:
                    choice2.color = new Color32(255, 255, 255, 255);
                    Arrow1.SetActive(false);
                    Arrow2.SetActive(true);
                    Arrow3.SetActive(false);
                    break;
                case 3:
                    choice3.color = new Color32(255, 255, 255, 255);
                    Arrow1.SetActive(false);
                    Arrow2.SetActive(false);
                    Arrow3.SetActive(true);
                    break;
            }
        }
    }
}
