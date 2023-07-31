using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

 // POLYMORPHISM 
 // MenuUIHandler = parent of Start button, Quit button, Input field SetPlayerName (childs) - but behave differently

public class MenuUIHandler: MonoBehaviour
{

    [SerializeField] Text PlayerNameInput;
   
    void StartGame() //Start button
    {
        SceneManager.LoadScene(1);
    }

    public void SetPlayerName() //Input field SetPlayerName
    {
        PlayerDataHandle.Instance.PlayerName = PlayerNameInput.text;
    }

    void ExitGame() //Quit Button
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}