using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Text guiLevel;

    private void FixedUpdate() {
        if (!guiLevel) return;
        guiLevel.text = string.Format("{0}", Level.curLevel);
    }

    public void Exit() {
        Application.Quit();
        Debug.Log("should have quit by now");
    }

    public void LoadLevel() {
        Framework.Fade("TestLevel", Color.black, 0.6f);
    }

    public void IncrementLevel()
    {
        Level.curLevel++;
    }

    public void DecrementLevel()
    {
        Level.curLevel--;
    }
}
