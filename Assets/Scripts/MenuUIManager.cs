using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuUIManager : MonoBehaviour
{
    public InputField InputPlayerName;
    public Text TextBestScore;

    public void Start()
    {
        string PlayerHighScoreComplete = PersistentManager.Instance.GetPlayerHighScoreForDisplay();
        TextBestScore.text = "Best score : " + PlayerHighScoreComplete;
    }

    public void LoadScene()
    {
        //  get player name then store it into MainManager
        PersistentManager.Instance.setPlayerName(InputPlayerName.text);
        // load main scene (game)
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();  // exit version In-Editor
#else
        Application.Quit();  // Attention : Application.Quit() works only in the built application
#endif
    }
 
}
