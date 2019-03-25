using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    public string[] levels;

    public void Exit() {
        Application.Quit();
        Debug.Log("should have quit by now");
    }

    public void LoadLevel() {
        Level.curLevel = 1;
        Framework.Fade("TestLevel", Color.black, 0.6f);
    }
}
