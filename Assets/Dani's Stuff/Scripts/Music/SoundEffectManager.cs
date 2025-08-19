using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager instance;
    private static AudioSource AudioSource;
    private static SoundEffectLibrary library;
    [SerializeField] private Slider sfxSlider;
    //Input Variables
    public float step = 0.1f;
    //gameobject
    public GameObject sfx;
    private void Awake()
    {
        //instance call
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
        //input ctrl
        if (sfx.activeSelf)
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
