using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Framework {

    public static bool areWeFading = false;

    public static void GameOver() {
        Fade("MainMenu", Color.black, 0.6f);
    }

    public static void SetHighScore(int level, int score) {
        int currentHighscore = SavedData.getInstance().highScore[level];
        if (score > currentHighscore) {
            SavedData.getInstance().highScore[level] = score;
        }
    }

    public static void NextLevel()
    {
        Level.curLevel++;
        Fade("TestLevel", Color.black, 0.6f);
    }

    public static void Fade(string scene, Color col, float multiplier)
    {
        if (areWeFading)
        {
            Debug.Log("Already Fading");
            return;
        }

        GameObject init = new GameObject();
        init.name = "Fader";
        Canvas myCanvas = init.AddComponent<Canvas>();
        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        init.AddComponent<Fader>();
        init.AddComponent<CanvasGroup>();
        init.AddComponent<Image>();

        Fader scr = init.GetComponent<Fader>();
        scr.fadeDamp = multiplier;
        scr.fadeScene = scene;
        scr.fadeColor = col;
        scr.start = true;
        areWeFading = true;
        scr.InitiateFader();

    }

    public static void DoneFading()
    {
        areWeFading = false;
    }
}