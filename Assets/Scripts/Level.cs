using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static int curLevel;
    public AudioSource menuMusic;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        //music stuff
        if (SceneManager.GetActiveScene().name != "MainMenu") {
            menuMusic.loop = false;
        }
        else {
            menuMusic.loop = true;
            if (!menuMusic.isPlaying) menuMusic.Play();
        }

        //everything else
        if (curLevel < 1) curLevel = 1;
    }

}
