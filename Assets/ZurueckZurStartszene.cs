using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ZurueckZurStartszene : MonoBehaviour
{
    public Schriftverwalter mSchriftverwalter;
    public TextMeshProUGUI mTextZurueck;

    void Update()
    {
        if (mTextZurueck != null && mSchriftverwalter != null)
        {
            mTextZurueck.font = mSchriftverwalter.LieferFont();
        }
    }
    public void LoadSceneStart()
    {
        // Szene wird geladen
        SceneManager.LoadScene("AlleNotizen_Start");
    }
}
