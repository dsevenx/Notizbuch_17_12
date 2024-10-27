using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AufloesungskuemmerEinstellungen : AufloesungskuemmerBase
{
    public RectTransform mInputFieldUeberschriften_RectTransform;
    public TextMeshProUGUI mUeberschriftenText;
    public TextMeshProUGUI mUeberschriftenTexPlaceholder;

    public RectTransform mInputFieldAbkuerzungen_RectTransform;
    public TextMeshProUGUI mAbkuerzungenText;
    public TextMeshProUGUI mAbkuerzungenTextPlaceholder;

   public RectTransform mDropDownFormate_RectTransform;
  

    void Start()
    {
        Initialisiere();
    }

    public override void Initialisiere()
    {
        base.Initialisiere();
     
        mDropDownFormate_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.08333f);
        mDropDownFormate_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight * 0.41f);

        mInputFieldUeberschriften_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.40f);
        mInputFieldUeberschriften_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight*0.16f );

        mInputFieldAbkuerzungen_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.40f);
        mInputFieldAbkuerzungen_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight * -0.25f);

        mUeberschriftenText.fontSize = mBasisSchrifthoehe * 1.05f;
        setzeLinksverschiebung(mUeberschriftenText);

        mUeberschriftenTexPlaceholder.fontSize = mBasisSchrifthoehe * 1.05f;
        setzeLinksverschiebung(mUeberschriftenTexPlaceholder);

        mAbkuerzungenText.fontSize = mBasisSchrifthoehe * 1.05f;
        setzeLinksverschiebung(mAbkuerzungenText);

        mAbkuerzungenTextPlaceholder.fontSize = mBasisSchrifthoehe * 1.05f;
        setzeLinksverschiebung(mAbkuerzungenTextPlaceholder);
  }

}
