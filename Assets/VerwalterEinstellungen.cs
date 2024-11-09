using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VerwalterEinstellungen : MonoBehaviour
{
    public AufloesungskuemmerEinstellungen mAufloesungskuemmerEinstellungen;

    public NotizBuchBL mNotizBuchBL;

    public TMP_InputField mUberschriftenTMP_InputField;

    public TMP_InputField mAbkuerzungenTMP_InputField;

    public TextMeshProUGUI mTextMeshProButton;

    public Boolean mBildaktualisiert = false;

    public Boolean mEinzelSchriftButtonAkitv = false;
    private const int K_ANZAHL_DARSTELLUNG = 5;

    public GameObject mGameObjectdUeberschrift;
    public GameObject mGameObjectAbkuerzung;
    public GameObject mGameObjectSchrift;

    public GameObject mGameObjectButtonSchriftItimRegularSDF;
    public GameObject mGameObjectButtonSchrifDancingScript_VariableFont_wght_SDF;
    public GameObject mGameObjectButtonSchriftFFjallaOne_Regular_SDF;
    public GameObject mGameObjectButtonSchriftIBMPlexSans_Regular_SDF;
    public GameObject mGameObjectButtonSchriftPlayfairDisplay_VariableFont_wght_SDF;

    public Schriftverwalter mSchriftverwalter;
    void Start()
    {
        mBildaktualisiert = false;
    }
    void Update()
    {
        if (mAufloesungskuemmerEinstellungen.IstFertig() && mNotizBuchBL.istEingelesen() && !mBildaktualisiert)
        {
            mUberschriftenTMP_InputField.text = mNotizBuchBL.LieferUerberschriftenString();
            mAbkuerzungenTMP_InputField.text = mNotizBuchBL.LieferAbkuerzugenString();
            setzeSchrift();

            mEinzelSchriftButtonAkitv = false;
            BlendeSchriftButtons();
            mBildaktualisiert = true;
        }
    }

    private void BlendeSchriftButtons()
    {
        mGameObjectButtonSchriftItimRegularSDF.SetActive(mEinzelSchriftButtonAkitv);
        mGameObjectButtonSchrifDancingScript_VariableFont_wght_SDF.SetActive(mEinzelSchriftButtonAkitv);
        mGameObjectButtonSchriftFFjallaOne_Regular_SDF.SetActive(mEinzelSchriftButtonAkitv);
        mGameObjectButtonSchriftIBMPlexSans_Regular_SDF.SetActive(mEinzelSchriftButtonAkitv);
        mGameObjectButtonSchriftPlayfairDisplay_VariableFont_wght_SDF.SetActive(mEinzelSchriftButtonAkitv);

        mGameObjectdUeberschrift.SetActive(!mEinzelSchriftButtonAkitv);
        mGameObjectAbkuerzung.SetActive(!mEinzelSchriftButtonAkitv);
    }

    public void setzeNeueSchrift(int pVersion)
    {
        mSchriftverwalter.SetAktiveVersion(pVersion);
        setzeSchrift();
        KlickAufSchriftButton();
    }

    private void setzeSchrift()
    {
        mTextMeshProButton.font = mSchriftverwalter.LieferFont();
        mUberschriftenTMP_InputField.textComponent.font = mSchriftverwalter.LieferFont();
        mAbkuerzungenTMP_InputField.textComponent.font = mSchriftverwalter.LieferFont();
    }

    public void KlickAufSchriftButton()
    {
        mEinzelSchriftButtonAkitv = !mEinzelSchriftButtonAkitv;
        BlendeSchriftButtons();
    }

    public bool IstAllesFertig()
    {
        return mBildaktualisiert;
    }
}
