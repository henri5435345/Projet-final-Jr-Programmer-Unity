using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataTransferScript : MonoBehaviour
{
    public InputField inputFieldMenu;

    public void SaveDataAndLoadMainScene()
    {
        string textToTransfer = inputFieldMenu.text;

        PlayerPrefs.SetString("TextToTransfer", textToTransfer);
        
        SceneManager.LoadScene("Main");
    }
}
