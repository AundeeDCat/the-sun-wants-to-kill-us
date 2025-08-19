using UnityEngine;
using UnityEngine.UI;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager instance;
    private static AudioSource AudioSource;
    private static SoundEffectLibrary library;
    public Slider sfxSlider;
    //Each step when moving the Volume Left & Right
    public float step = 0.1f;
    //Call setup & ingame gameobject
    //private SetupDefaults MainMenu;
    //private PauseMenu InGame;
    //MyScript myObject = FindObjectOfType<MyScript>();
    SetupDefaults MainMenu = FindAnyObjectByType<SetupDefaults>();
    
    private void Awake()
    {

        //instance 
        if (instance == null)
        {
            instance = this;
            AudioSource = GetComponent<AudioSource>();
            library = GetComponent<SoundEffectLibrary>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public static void Play(string soundName)
    {
        AudioClip audioClip = library.GetRandomClip(soundName);
        if(audioClip != null )
        {
            AudioSource.PlayOneShot(audioClip);
        }
    }
    void Start()
    {
        sfxSlider.onValueChanged.AddListener(delegate { OnValueChanged(); });
    }

    void Update()
    {
        //check if scripts are active
        if (gameObject.GetComponent<SettingsOption>().enabled == true || gameObject.GetComponent<PauseMenu>().enabled == true)
        {
            //checks if gameobject is active;
            if (MainMenu.isActiveAndEnabled || InGame.isActiveAndEnabled)
            {
                sfxSlider.interactable = true;
            }
            else if (!MainMenu.isActiveAndEnabled || !InGame.isActiveAndEnabled)
            {
                sfxSlider.interactable = false;
            }
        }
        else

        if (sfxSlider.interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                sfxSlider.value += step;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                sfxSlider.value -= step;
            }
        }
    }

    public static void SetVolume(float volume)
    {
        AudioSource.volume = volume;
    }

    public void OnValueChanged()
    {
        SetVolume(sfxSlider.value);
    }
    //Updates ScaleMove on Handler

}
