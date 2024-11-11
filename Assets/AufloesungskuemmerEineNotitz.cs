using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AufloesungskuemmerEineNotitz : AufloesungskuemmerBase
{
    // Überschrift
    public RectTransform mInputFieldUeberschrift_RectTransform;
    public TextMeshProUGUI mUeberschriftText;

   public  Schriftverwalter mSchriftverwalter;

    // moeglische Überschriften
    public RectTransform mButton_01_RectTransform;
    public RectTransform mButton_02_RectTransform;
    public RectTransform mButton_03_RectTransform;
    public RectTransform mButton_04_RectTransform;
    public TextMeshProUGUI mButton_01_Text;
    public TextMeshProUGUI mButton_02_Text;
    public TextMeshProUGUI mButton_03_Text;
    public TextMeshProUGUI mButton_04_Text;

    // Notiz selbst

    public RectTransform mInputFieldNotiz_RectTransform;
    public TextMeshProUGUI mNotizText;

    void Start()
    {
        Initialisiere();

    }

    public override void Initialisiere()
    {
        base.Initialisiere();

        mInputFieldUeberschrift_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.08333f);
        mInputFieldUeberschrift_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight * 0.41f);
        setzeLinksverschiebung(mUeberschriftText);

        mButton_01_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.08333f);
        mButton_01_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight * 0.33f);
        mButton_02_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.08333f);
        mButton_02_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight * 0.25f);
        mButton_03_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.08333f);
        mButton_03_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight * 0.17f);
        mButton_04_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.08333f);
        mButton_04_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight * 0.09f);

        mInputFieldNotiz_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.81f);
        mInputFieldNotiz_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight * (-0.0405f));

        mUeberschriftText.fontSize = mBasisSchrifthoehe * 1.2f;
        mNotizText.fontSize = mBasisSchrifthoehe * 1.05f;
        mNotizText.font = mSchriftverwalter.LieferFont();
        setzeLinksverschiebung(mNotizText);
       
        mButton_01_Text.fontSize = mBasisSchrifthoehe * 1.15f;
        setzeLinksverschiebung(mButton_01_Text);
        mButton_01_Text.font = mSchriftverwalter.LieferFont();

        mButton_02_Text.fontSize = mBasisSchrifthoehe * 1.15f;
        setzeLinksverschiebung(mButton_02_Text);
        mButton_02_Text.font = mSchriftverwalter.LieferFont();

        mButton_03_Text.fontSize = mBasisSchrifthoehe * 1.15f;
        setzeLinksverschiebung(mButton_03_Text);
        mButton_03_Text.font = mSchriftverwalter.LieferFont();

        mButton_04_Text.fontSize = mBasisSchrifthoehe * 1.15f;
        setzeLinksverschiebung(mButton_04_Text);
        mButton_04_Text.font = mSchriftverwalter.LieferFont();

    }

   
}
