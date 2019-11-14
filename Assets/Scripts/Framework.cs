using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Framework {

    public static bool areWeFading = false;
    public static int hsLevel = 0;
    public static int hsScore = 0;

    public static void GameOver(int score) {
        //if (score > hsScore) hsScore = score;
        //if (Level.curLevel > hsLevel) hsLevel = Level.curLevel;
        Fade("MainMenu", Color.black, 0.6f);
    }

    public static void SetHighScore(int level, int score) {

        if (!SavedData.getInstance().highScore.ContainsKey(level))
        {
             SavedData.getInstance().highScore.Add(level, score);
        }
        int currentHighscore = SavedData.getInstance().highScore[level];
        if (score > currentHighscore) {
            SavedData.getInstance().highScore[level] = score;
        }
        foreach (KeyValuePair<int, int> kvp in SavedData.getInstance().highScore)
        {
            Debug.Log(kvp);
        }
    }

    public static int GetHighScore()
    {
        int temp = 0;
        foreach (KeyValuePair<int, int> kvp in SavedData.getInstance().highScore)
        {
            temp += kvp.Value;
        }
        return temp;
    }

    public static void NextLevel()
    {
        Level.curLevel++;
        Fade("TestLevel", Color.black, 0.6f);
    }

    public static void PrevLevel()
    {
        Level.curLevel--;
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