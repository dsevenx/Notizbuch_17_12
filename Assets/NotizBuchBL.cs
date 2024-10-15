using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NotizBuchBL : MonoBehaviour
{
    private const char Separator = ',';
    private readonly string K_ALLE_IDS = "ALLE_IDS";
    private readonly string K_AKTIVE_NOTIZ = "AKTIVE_NOTIZ";
    public Dictionary<int, NotizBuchBL_eineNotiz> mDictionaryAlleNoitzen;

    Boolean mDictionaryAlleNoitzenEingelesen = false;

    void Start()
    {
        mDictionaryAlleNoitzen = new Dictionary<int, NotizBuchBL_eineNotiz>();

        Einlesen();

        mDictionaryAlleNoitzenEingelesen = true;
    }

    public Boolean istEingelesen()
    {
        return mDictionaryAlleNoitzenEingelesen;
    }

    public void NeueNotiz()
    {
        int lMax = 1;
        if (mDictionaryAlleNoitzen.Count == 0)
        {
            PlayerPrefs.SetString(K_ALLE_IDS, "" + lMax);
        }
        else
        {
            foreach (KeyValuePair<int, NotizBuchBL_eineNotiz> lKeyValuePair in mDictionaryAlleNoitzen)
            {
                if (lKeyValuePair.Key > lMax)
                {
                    lMax = lKeyValuePair.Key;
                }
            }
            lMax++;

            string lAlleIDsString = PlayerPrefs.GetString(K_ALLE_IDS) + Separator + lMax;

            PlayerPrefs.SetString(K_ALLE_IDS, lAlleIDsString);
        }

        Einlesen();

        SetzeAktiveNotiz(lMax);
    }

    public NotizBuchBL_eineNotiz getAktiveNotiz()
    {
       return mDictionaryAlleNoitzen[PlayerPrefs.GetInt(K_AKTIVE_NOTIZ)];
    }

    public void SetzeAktiveNotiz(int pAktiveNotiz)
    {
        PlayerPrefs.SetInt(K_AKTIVE_NOTIZ, pAktiveNotiz);

        DateTime jetzt = DateTime.Now;

        string lJetztDatumUhrzeit = jetzt.ToString("dd.MM.yy HH:mm");

        getAktiveNotiz().SetDatum(lJetztDatumUhrzeit);
    }
    private void Einlesen()
    {
        mDictionaryAlleNoitzen.Clear();

        string lAlleIDsString = PlayerPrefs.GetString(K_ALLE_IDS);

        string[] lAlleIDsS = lAlleIDsString.Split(Separator);

        foreach (string lIDString in lAlleIDsS)
        {
            int lID = int.Parse(lIDString);
            mDictionaryAlleNoitzen[lID] =  new NotizBuchBL_eineNotiz(lID);
        }
    }

    internal void LoescheNotiz(int pID)
    {
        mDictionaryAlleNoitzen[pID].SetUebeschrift("");
        mDictionaryAlleNoitzen[pID].SetDatum("");
        mDictionaryAlleNoitzen[pID].SetText("");
        mDictionaryAlleNoitzen.Remove(pID);

        string lAlleIDString = "";
        foreach (KeyValuePair<int, NotizBuchBL_eineNotiz> lKeyValuePair in mDictionaryAlleNoitzen)
        {
            if (lAlleIDString == "")
            {
                lAlleIDString = "" + lKeyValuePair.Key;
            }
            else
            {
                lAlleIDString = lAlleIDString + Separator + lKeyValuePair.Key;
            }
        }

        PlayerPrefs.SetString(K_ALLE_IDS, lAlleIDString);

        Einlesen();
    }

    internal void SetzeUeberschriftAktiveNotiz(string pUeberschrift)
    {
       getAktiveNotiz().SetUebeschrift(pUeberschrift);
    }

    internal void SetzeTextAktiveNotiz(string pText)
    {
        getAktiveNotiz().SetText(pText);
    }
}
