using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataTransferScriptMain : MonoBehaviour
{
    public Text textMain;

    void Start()
    {
        // Récupérer la valeur stockée dans les PlayerPrefs
        string transferredText = PlayerPrefs.GetString("TextToTransfer");

        // Afficher la valeur dans le Text
        textMain.text = transferredText;
    }
}
