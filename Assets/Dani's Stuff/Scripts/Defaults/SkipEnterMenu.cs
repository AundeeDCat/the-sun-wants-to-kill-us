using UnityEngine;

public class SkipEnterMenu : MonoBehaviour
{
    public bool Norepeat;
    public static SkipEnterMenu Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Norepeat = false;
    }
}
