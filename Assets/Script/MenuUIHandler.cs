using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
public class MenuUIHandler: MonoBehaviour
{

    [SerializeField] Text PlayerNameInput;
    // INHERITANCE
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    // INHERITANCE
    public void SetPlayerName()
    {
        PlayerDataHandle.Instance.PlayerName = PlayerNameInput.text;
    }
// INHERITANCE
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}