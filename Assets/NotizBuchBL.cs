using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NotizBuchBL : MonoBehaviour
{
    private const char Separator = ',';
    private readonly string K_ALLE_ABKS = "ALLE_ABKS";
    private readonly string K_ALLE_IDS = "ALLE_IDS";

    private readonly string K_ALLE_UEBERSCHRIFTENS = "ALLE_UEBERSCHRIFTENS";

    private readonly string K_AKTIVE_NOTIZ = "AKTIVE_NOTIZ";
    public Dictionary<int, NotizBuchBL_eineNotiz> mDictionaryAlleNotizen;

    public Dictionary<int, NotizBuchBL_eineAbkuerzung> mDictionaryAlleAbkuerzungen;

    public Dictionary<int, NotizBuchBL_eineUeberschrift> mDictionaryAlleUeberschriften;

    Boolean mDictionariesEingelesen = false;

    void Start()
    {
        mDictionaryAlleNotizen = new Dictionary<int, NotizBuchBL_eineNotiz>();
        mDictionaryAlleAbkuerzungen = new Dictionary<int, NotizBuchBL_eineAbkuerzung>();
        mDictionaryAlleUeberschriften = new Dictionary<int, NotizBuchBL_eineUeberschrift>();

        Einlesen();

        mDictionariesEingelesen = true;
    }

    public Boolean istEingelesen()
    {
        return mDictionariesEingelesen;
    }

    public void NeueNotiz()
    {
        int lMax = 1;
        if (mDictionaryAlleNotizen.Count == 0)
        {
            PlayerPrefs.SetString(K_ALLE_IDS, "" + lMax);
        }
        else
        {
            foreach (KeyValuePair<int, NotizBuchBL_eineNotiz> lKeyValuePair in mDictionaryAlleNotizen)
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
        return mDictionaryAlleNotizen[PlayerPrefs.GetInt(K_AKTIVE_NOTIZ)];
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
        mDictionaryAlleNotizen.Clear();

        string lAlleIDsStringNotiz = PlayerPrefs.GetString(K_ALLE_IDS);

        string[] lAlleIDsNotiz = lAlleIDsStringNotiz.Split(Separator);

        foreach (string lIDString in lAlleIDsNotiz)
        {
            int lID = ermittelID(lIDString);
            if (lID > 0) {
               mDictionaryAlleNotizen[lID] = new NotizBuchBL_eineNotiz(lID);
            }
        }

        mDictionaryAlleAbkuerzungen.Clear();

        string lAlleIDsStringAbk = PlayerPrefs.GetString(K_ALLE_ABKS);

        string[] lAlleIDsABK = lAlleIDsStringAbk.Split(Separator);

        foreach (string lIDString in lAlleIDsABK)
        {
            int lID = ermittelID(lIDString);
            if (lID > 0) {
                mDictionaryAlleAbkuerzungen[lID] = new NotizBuchBL_eineAbkuerzung(lID);
            }
        }

        mDictionaryAlleUeberschriften.Clear();

        string lAlleIDsStringUeberschriften = PlayerPrefs.GetString(K_ALLE_UEBERSCHRIFTENS);

        string[] lAlleIDUeberschriften = lAlleIDsStringUeberschriften.Split(Separator);

        foreach (string lIDString in lAlleIDUeberschriften)
        {
            int lID = ermittelID(lIDString);
            if (lID > 0) {
                mDictionaryAlleUeberschriften[lID] = new NotizBuchBL_eineUeberschrift(lID);
            }
        }
    }

    private int ermittelID(string lIDString)
    {
         int lErg;

         if (!int.TryParse(lIDString, out lErg))
        {
            lErg = 0; 
        }

        return lErg;
    }

    internal void LoescheNotiz(int pID)
    {
        mDictionaryAlleNotizen[pID].SetUebeschrift("");
        mDictionaryAlleNotizen[pID].SetDatum("");
        mDictionaryAlleNotizen[pID].SetText("");
        mDictionaryAlleNotizen.Remove(pID);

        string lAlleIDString = "";
        foreach (KeyValuePair<int, NotizBuchBL_eineNotiz> lKeyValuePair in mDictionaryAlleNotizen)
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

    public void ergaenzeUeberschrift(string pText)
    {
        int lMax = 1;
        if (mDictionaryAlleUeberschriften.Count == 0)
        {
            PlayerPrefs.SetString(K_ALLE_UEBERSCHRIFTENS, "" + lMax);
        }
        else
        {
            bool lUeberschriftVorhanden = false;
            foreach (KeyValuePair<int, NotizBuchBL_eineUeberschrift> lKeyValuePair in mDictionaryAlleUeberschriften)
            {
                if (lKeyValuePair.Key > lMax)
                {
                    lMax = lKeyValuePair.Key;
                }
                if (string.Equals(lKeyValuePair.Value.GetUeberschrift(), pText, StringComparison.OrdinalIgnoreCase))
                {
                    lUeberschriftVorhanden = true;
                }
            }

            if (!lUeberschriftVorhanden)
            {
                lMax++;
                NotizBuchBL_eineUeberschrift lNeueNotizBuchBL_eineUeberschrift = new NotizBuchBL_eineUeberschrift(lMax);

                string lAlleIDsString = PlayerPrefs.GetString(K_ALLE_UEBERSCHRIFTENS) + Separator + lMax;

                PlayerPrefs.SetString(K_ALLE_UEBERSCHRIFTENS, lAlleIDsString);

                lNeueNotizBuchBL_eineUeberschrift.SetUeberschrift(pText);
                mDictionaryAlleUeberschriften.Add(lMax, lNeueNotizBuchBL_eineUeberschrift);
            }
        }
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
