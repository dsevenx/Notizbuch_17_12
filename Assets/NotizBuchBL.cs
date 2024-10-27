using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class NotizBuchBL : MonoBehaviour
{
    private const char K_SEPARATOR_NOTIZ_ID = ',';
    private const char K_NEW_LINE = '\n';

    private const char K_ABK_Separator = ':';

    private readonly string K_ALLE_ABKS = "ALLE_ABKS";
    private readonly string K_ALLE_IDS = "ALLE_IDS";

    private readonly string K_ALLE_UEBERSCHRIFTENS = "ALLE_UEBERSCHRIFTENS";

    private readonly string K_AKTIVE_NOTIZ = "AKTIVE_NOTIZ";
    public Dictionary<int, NotizBuchBL_eineNotiz> mDictionaryAlleNotizen;

    public String mAlleAbkuerzungen;

    public String mAlleUeberschriften;

    Boolean mDictionariesEingelesen = false;

    void Start()
    {
        mDictionaryAlleNotizen = new Dictionary<int, NotizBuchBL_eineNotiz>();
        mAlleAbkuerzungen = "";
        mAlleUeberschriften = "";

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

            string lAlleIDsString = PlayerPrefs.GetString(K_ALLE_IDS) + K_SEPARATOR_NOTIZ_ID + lMax;

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
        // Noitzen einlesen
        mDictionaryAlleNotizen.Clear();

        string lAlleIDsStringNotiz = PlayerPrefs.GetString(K_ALLE_IDS);

        string[] lAlleIDsNotiz = lAlleIDsStringNotiz.Split(K_SEPARATOR_NOTIZ_ID);

        List<String> lUberschriftAusNotizen = new List<string>();
        foreach (string lIDString in lAlleIDsNotiz)
        {
            int lID = ermittelID(lIDString);
            if (lID > 0)
            {
                mDictionaryAlleNotizen[lID] = new NotizBuchBL_eineNotiz(lID);

                lUberschriftAusNotizen.Add(mDictionaryAlleNotizen[lID].GetUebeschrift());
            }
        }

        // Abkürzungen einlesen
        mAlleAbkuerzungen = PlayerPrefs.GetString(K_ALLE_ABKS);

        // Überschriften einlesen
        mAlleUeberschriften = PlayerPrefs.GetString(K_ALLE_UEBERSCHRIFTENS);

        foreach (string lUberschrift in lUberschriftAusNotizen)
        {
            mAlleUeberschriften = AnhaengenMitSeparator(mAlleUeberschriften, K_NEW_LINE, lUberschrift);
        }

        string lUberschriftzusammgefasst = "";
        foreach (string lUeber in LieferUerberschriftenAusString(mAlleUeberschriften))
        {
            if (lUeber != "" && !IstUeberschriftVorhanden(lUeber, LieferUerberschriftenAusString(lUberschriftzusammgefasst)))
            {
                lUberschriftzusammgefasst = AnhaengenMitSeparator(lUberschriftzusammgefasst, K_NEW_LINE, lUeber);
            }
        }

        SetzeUeberschriften(lUberschriftzusammgefasst);
    }

    public List<NotizBuchBL_eineAbkuerzung> LieferAbkuerzungsliste()
    {
        List<NotizBuchBL_eineAbkuerzung> lErg = new List<NotizBuchBL_eineAbkuerzung>();

        string[] lAlleIDsABK = LieferAbkuerzugenString().Split(K_NEW_LINE);

        foreach (string lIDString in lAlleIDsABK)
        {
            string[] lEineAbkuerzung = lIDString.Split(K_ABK_Separator);

            if (lEineAbkuerzung.Count() == 2)
            {
                lErg.Add(new NotizBuchBL_eineAbkuerzung(lEineAbkuerzung[0].Trim(), lEineAbkuerzung[1].Trim()));
            }
        }

        return lErg;
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
                lAlleIDString = lAlleIDString + K_SEPARATOR_NOTIZ_ID + lKeyValuePair.Key;
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

    private string AnhaengenMitSeparator(string lGesamtString, char pSeparator, string lNeu)
    {
        if (lGesamtString == "")
        {
            return lNeu;
        }
        else
        {
            return lGesamtString + pSeparator + lNeu;
        }
    }

    internal List<string> LieferUerberschriftenAusString(string pUeberschrift)
    {
        List<string> lErg = new List<string>();

        string[] lAlleIDUeberschriften = pUeberschrift.Split(K_NEW_LINE);

        foreach (string lIDString in lAlleIDUeberschriften)
        {
            lErg.Add(lIDString);
        }

        return lErg;
    }
    internal List<string> LieferUerberschriftenAusString()
    {
        return LieferUerberschriftenAusString(mAlleUeberschriften);
    }

    public void SetzeUeberschriften(string pUeberschriften)
    {
        mAlleUeberschriften = pUeberschriften;
        PlayerPrefs.SetString(K_ALLE_UEBERSCHRIFTENS, pUeberschriften);
    }
    internal string LieferUerberschriftenString()
    {
        return mAlleUeberschriften;
    }


    internal bool IstUeberschriftVorhanden(string pText, List<string> pAlleUeberschriften)
    {
        foreach (String lUeberschrift in pAlleUeberschriften)
        {
            if (lUeberschrift == pText)
            {
                return true;
            }
        }

        return false;
    }
    internal bool IstUeberschriftVorhanden(string pText)
    {
         return IstUeberschriftVorhanden(pText,LieferUerberschriftenAusString(mAlleUeberschriften));
    }

    public void SetzeAbkuerzungen(string pAbkuerzungen)
    {
        mAlleAbkuerzungen = pAbkuerzungen;
        PlayerPrefs.SetString(K_ALLE_ABKS, pAbkuerzungen);
    }

    internal string LieferAbkuerzugenString()
    {
        return mAlleAbkuerzungen;
    }

    internal string BeachteAbkuerzungen(string pText)
    {
        string lText = pText;
        foreach (NotizBuchBL_eineAbkuerzung lAbk in LieferAbkuerzungsliste()) {
           lText = lText.Replace(lAbk.getAbk(),lAbk.getAbkText());
           lText = lText.Replace(lAbk.getAbk().ToLower(),lAbk.getAbkText());
           lText = lText.Replace(lAbk.getAbk().ToUpper(),lAbk.getAbkText());
        }
        return lText;
    }
}
