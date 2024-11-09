using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AufloesungskuemmerBase : MonoBehaviour
{
    public RectTransform mNotizPanel;

    public RectTransform mButtonPanel;

    public RectTransform mButtonLinks;
    public RectTransform mButtonRechts;

    public TextMeshProUGUI mTextButtonLinks;
    public TextMeshProUGUI mTextButtonRechts;

    public int mBasisSchrifthoehe;
    public int mBasisTextverschiebung;

    public int mRelevanteBreiteEineNotiz;
    public float mRelevanteBreiteEineNotizAnker;
   
    public int mScreenWidth;
    public int mScreenHeight;

    public virtual void Initialisiere()
    {
        mScreenWidth = Display.main.systemWidth;
        mScreenHeight = Display.main.systemHeight;
        mBasisSchrifthoehe = (int)(mScreenWidth * 0.04f);
        mBasisTextverschiebung = (int)(mScreenWidth * 0.01f);
  
        // alles zu der Notizübersicht
        mNotizPanel.sizeDelta = new Vector2(mScreenWidth, mScreenHeight * 0.91666f);
        mNotizPanel.anchoredPosition = new Vector2(0, mScreenHeight * 0.0415f);

        // alles zu einer Notiz
        mRelevanteBreiteEineNotiz = (int)(mScreenWidth * 0.96f);
        mRelevanteBreiteEineNotizAnker = 0.04f / 2;
  
        // alles zum ButtonPanel
        float lSollHoeheButtonPanel = mScreenHeight * 0.08333f;
        mButtonPanel.sizeDelta = new Vector2(mScreenWidth, lSollHoeheButtonPanel);
        mButtonPanel.anchoredPosition = new Vector2(0, -mScreenHeight / 2 + lSollHoeheButtonPanel / 2);

        float panelWidth = mButtonPanel.rect.width;
        float panelHeight = mButtonPanel.rect.height;

        float buttonWidth = panelWidth * 0.46f;
        float buttonHeight = panelHeight * 0.91666f;

        mButtonLinks.sizeDelta = new Vector2(buttonWidth, buttonHeight);
        mButtonLinks.anchoredPosition = new Vector2(-(panelWidth / 4), 0);
        mTextButtonLinks.fontSize = mBasisSchrifthoehe;

        mButtonRechts.sizeDelta = new Vector2(buttonWidth, buttonHeight);
        mButtonRechts.anchoredPosition = new Vector2((panelWidth / 4), 0);
        mTextButtonRechts.fontSize = mBasisSchrifthoehe;
    }

     public void setzeLinksverschiebung(TextMeshProUGUI pTextMeshProUGUI)
    {
       Vector4 lMargin = pTextMeshProUGUI.margin;
       lMargin.x = mBasisTextverschiebung;
       pTextMeshProUGUI.margin = lMargin;
    }
     public void setzeRechtsverschiebung(TextMeshProUGUI pTextMeshProUGUI)
    {
       Vector4 lMargin = pTextMeshProUGUI.margin;
       lMargin.z = mBasisTextverschiebung;
       pTextMeshProUGUI.margin = lMargin;
    }

    public Boolean IstFertig()
    {
        return mBasisSchrifthoehe > 0;
    }
}
