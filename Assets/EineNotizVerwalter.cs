using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EineNotizVerwalter : MonoBehaviour
{
    // Überschrift

    public TMP_InputField mInputFieldUeberschrift_TMP;

    public TMP_InputField mInputFieldNotiztext_TMP;

    // moeglische Überschriften
    public GameObject mButton_01;
    public TextMeshProUGUI mButton_01_Text;
    public GameObject mButton_02;

    public TextMeshProUGUI mButton_02_Text;
    public GameObject mButton_03;

    public TextMeshProUGUI mButton_03_Text;
    public GameObject mButton_04;

    public TextMeshProUGUI mButton_04_Text;

    private List<string> mAlleUeberschriften = new List<string>();

    public NotizBuchBL mNotizBuchBL;

    public Boolean mStarterfolgreich = false;

    void Start()
    {
        mStarterfolgreich = false;
    }
    void Update()
    {
        if (mNotizBuchBL.istEingelesen())
        {
            mAlleUeberschriften = new List<string>();
            mAlleUeberschriften.Add("Latain");
            mAlleUeberschriften.Add("Mathe");
            mAlleUeberschriften.Add("Hase");
            mAlleUeberschriften.Add("Kaputt");
            mAlleUeberschriften.Add("nox");
            mAlleUeberschriften.Add("nix");
            mAlleUeberschriften.Add("fix");

            mInputFieldUeberschrift_TMP.onValueChanged.AddListener(PopulateOptions);

            mInputFieldUeberschrift_TMP.text = mNotizBuchBL.getAktiveNotiz().GetUebeschrift();
            mInputFieldNotiztext_TMP.text = mNotizBuchBL.getAktiveNotiz().GetText();

            BlendeAlleButtonAus();
            mStarterfolgreich = true;
        }
    }

    void PopulateOptions(string pText)
    {
        BlendeAlleButtonAus();

        if (pText.Length > 0)
        {

            int lButton = 0;
            foreach (string option in mAlleUeberschriften)
            {
                if (option.ToLower().Contains(pText))
                {
                    if (lButton == 0)
                    {
                        mButton_01.SetActive(true);
                        mButton_01_Text.text = option;
                    }
                    else if (lButton == 1)
                    {
                        mButton_02.SetActive(true);
                        mButton_02_Text.text = option;
                    }
                    else if (lButton == 2)
                    {
                        mButton_03.SetActive(true);
                        mButton_03_Text.text = option;
                    }
                    else if (lButton == 3)
                    {
                        mButton_04.SetActive(true);
                        mButton_04_Text.text = option;
                    }
                    lButton++;
                }
            }
        }
    }

    void BlendeAlleButtonAus()
    {
        mButton_01.SetActive(false);
        mButton_02.SetActive(false);
        mButton_03.SetActive(false);
        mButton_04.SetActive(false);
    }

    public void OnOptionSelected(TextMeshProUGUI pTextMeshProUGUI)
    {
        mInputFieldUeberschrift_TMP.text = pTextMeshProUGUI.text;
        SetzeUeberschriftAktiveNotiz(pTextMeshProUGUI.text);

        BlendeAlleButtonAus();
    }

    public void SetzeUeberschriftAktiveNotiz(string pUeberschrift)
    {
        mInputFieldUeberschrift_TMP.text = pUeberschrift;
        mNotizBuchBL.SetzeUeberschriftAktiveNotiz(pUeberschrift);
    }
    public void SetzeTextAktiveNotiz(string pText)
    {
        mInputFieldNotiztext_TMP.text = pText;
        mNotizBuchBL.SetzeTextAktiveNotiz(pText);
    }
}
