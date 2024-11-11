using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Schriftverwalter : MonoBehaviour
{
    public TMP_FontAsset mTMP_FontAsset_ItimRegularSDF;
    public TMP_FontAsset mTMP_FontAsset_DancingScript_VariableFont_wght_SDF;
    public TMP_FontAsset mTMP_FontAsset_FFjallaOne_Regular_SDF;
    public TMP_FontAsset mTMP_FontAsset_IBMPlexSans_Regular_SDF;
    public TMP_FontAsset mTMP_FontAsset_PlayfairDisplay_VariableFont_wght_SDF;


    private readonly string K_AKTIVE_VERSION = "K_AKTIVE_SCHRIFT_VERSION";
    public TMP_FontAsset LieferFont(int pVersion)
    {
        if (pVersion == 0)
        {
            return mTMP_FontAsset_ItimRegularSDF;
        }
        else if (pVersion == 1)
        {
            return mTMP_FontAsset_DancingScript_VariableFont_wght_SDF;
        }
        else if (pVersion == 2)
        {
            return mTMP_FontAsset_FFjallaOne_Regular_SDF;
        }
        else if (pVersion == 3)
        {
            return mTMP_FontAsset_IBMPlexSans_Regular_SDF;
        }
        else
        {
            return mTMP_FontAsset_PlayfairDisplay_VariableFont_wght_SDF;
        }
    }
    public TMP_FontAsset LieferFont()
    {
        return LieferFont(GetAktiveVersion());
    }

     public string LieferFarbe()
    {
        return LieferFarbe(GetAktiveVersion());
    }

    public int GetAktiveVersion()
    {
        return PlayerPrefs.GetInt(K_AKTIVE_VERSION);
    }

    public void SetAktiveVersion(int pVersion)
    {
        PlayerPrefs.SetInt(K_AKTIVE_VERSION, pVersion);
    }

    internal string LieferFarbe(int pVersion)
    {
        if (pVersion == 0)
        {
            return "<color=\"red\">";
        }
        else if (pVersion == 1)
        {
            return "<color=#F30000>";
        }
        else if (pVersion == 2)
        {
            return "<color=#FF5500>";
        }
        else if (pVersion == 3)
        {
            return "<color=#FE0000>";
        }
        else
        {
            return "<color=#FA0000>";
        }
    }
}
