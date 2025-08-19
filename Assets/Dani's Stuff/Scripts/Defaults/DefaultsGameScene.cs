using UnityEngine;

public class DefaultsGameScene : MonoBehaviour
{
    public GameObject Menu;
    //pause
    public static bool gameIsPaused;
    void Start()
    {
        Menu.SetActive(false);
        gameObject.GetComponent<PauseMenu>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.GetComponent<PauseMenu>().enabled = true;
            if (Menu.activeSelf)
            {
                Menu.SetActive(false);
                gameObject.GetComponent<PauseMenu>().enabled = false;
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
}
