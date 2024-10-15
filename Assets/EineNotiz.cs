using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class EineNotiz : MonoBehaviour
{
    public RectTransform mNotiz;
    public RectTransform mNotizUeberschrift;
    public RectTransform mNotizText;
    public RectTransform mNotizDatum;
    public RectTransform mNotizButtonPapierkorb;
    public RectTransform mNotizButtonBearbeiten;

    public TextMeshProUGUI mNotizUeberschriftText;
    public TextMeshProUGUI mNotizDatumText;
    public TextMeshProUGUI mNotizTextText;
    public TextMeshProUGUI motizButtonPapierkorbText;
    public TextMeshProUGUI mNotizButtonBearbeitenText;

    private int mRelevanteBreite;
    private int mRelevanteHoehe;
    private int mBasisTextverschiebung;

    private float mRelevanteBreiteAnker;
    private int mBasisSchrifthoehe;

    private Notizverwalter mNotizverwalter;

    private int mID; 

    void Update()
    {

        if (mRelevanteBreite > 0)
        {
            float lBreite01_12tel = mRelevanteBreite * 0.0833f;
            float lBreite02_12tel = mRelevanteBreite * 0.166f;
            float lBreite03_12tel = mRelevanteBreite * 0.25f;
            float lBreite05_12tel = mRelevanteBreite * 0.416f;
            float lBreite06_12tel = mRelevanteBreite * 0.5f;
            float lBreite10_12tel = mRelevanteBreite * 0.833f;

            float lSollHoehe_015_12 = mRelevanteHoehe * 0.125f;
            float lSollHoehe_03_12 = mRelevanteHoehe * 0.25f;
            float lSollHoehe_04_12 = mRelevanteHoehe * 0.3333f;
            float lSollHoehe_045_12 = mRelevanteHoehe * 0.375f;
            float lSollHoehe_085_12 = mRelevanteHoehe * 0.7083f;

            mNotiz.sizeDelta = new Vector2(mRelevanteBreite, mRelevanteHoehe);
            mNotiz.anchorMax = new Vector2(mRelevanteBreiteAnker, 1f);
            mNotiz.anchorMin = new Vector2(mRelevanteBreiteAnker, 1f);

            mNotizUeberschrift.sizeDelta = new Vector2(lBreite06_12tel, lSollHoehe_03_12);
            mNotizUeberschrift.anchoredPosition = new Vector2(mBasisTextverschiebung - lBreite03_12tel, lSollHoehe_045_12);

            mNotizDatum.sizeDelta = new Vector2(lBreite03_12tel, lSollHoehe_03_12);
            mNotizDatum.anchoredPosition = new Vector2(lBreite02_12tel, lSollHoehe_045_12);

            mNotizText.sizeDelta = new Vector2(lBreite10_12tel - 2 * mBasisTextverschiebung, lSollHoehe_085_12);
            mNotizText.anchoredPosition = new Vector2(mBasisTextverschiebung - lBreite01_12tel, -lSollHoehe_015_12);

            mNotizButtonPapierkorb.sizeDelta = new Vector2(lBreite02_12tel, lSollHoehe_04_12);
            mNotizButtonPapierkorb.anchoredPosition = new Vector2(lBreite05_12tel, lSollHoehe_04_12);

            mNotizButtonBearbeiten.sizeDelta = new Vector2(lBreite02_12tel, lSollHoehe_04_12);
            mNotizButtonBearbeiten.anchoredPosition = new Vector2(lBreite05_12tel, 0);

            // Schriftgrösse
            mNotizUeberschriftText.fontSize = mBasisSchrifthoehe * 1.1f;
            mNotizDatumText.fontSize = mBasisSchrifthoehe*0.9f;
            mNotizTextText.fontSize = mBasisSchrifthoehe * 0.7f;
            motizButtonPapierkorbText.fontSize = mBasisSchrifthoehe *.74f;
            mNotizButtonBearbeitenText.fontSize = mBasisSchrifthoehe*.74f;
        }
    }

    public void Initialisiere(int pRelevanteBreite, int pRelevanteHoehe, int pBasisTextverschiebung, float pRelevanteBreiteAnker,  
    int pBasisSchrifthoehe, string pUeberschrift, string pDatum, string pText,  Notizverwalter pNotizverwalter, int pID)
    {
        mRelevanteBreite = pRelevanteBreite;
        mRelevanteHoehe = pRelevanteHoehe;
        mBasisTextverschiebung = pBasisTextverschiebung;
        mRelevanteBreiteAnker = pRelevanteBreiteAnker;
        mBasisSchrifthoehe = pBasisSchrifthoehe;
        
        mNotizUeberschriftText.text = pUeberschrift;
        mNotizDatumText.text = pDatum;
        mNotizTextText.text = pText;
        mNotizverwalter = pNotizverwalter;
        mID = pID;
   }

   public void KlickeBearbeiten() {
       mNotizverwalter.KlickeBearbeiten(mID);
   }

    public void KlickeLoeschen() {
       mNotizverwalter.KlickeLoeschen(mID);
   }
}
