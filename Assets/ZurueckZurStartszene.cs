using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ZurueckZurStartszene : MonoBehaviour
{
    public void LoadSceneStart()
    {
        // Szene wird geladen
        SceneManager.LoadScene("AlleNotizen_Start");
    }
}
