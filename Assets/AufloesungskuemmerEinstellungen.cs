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


    public RectTransform mButton_AuswahlFarbeUndSchrift_RectTransform;
    public TextMeshProUGUI mButton_AuswahlFarbeUndSchrift_Text;

    public RectTransform mButton_01_RectTransform;
    public RectTransform mButton_02_RectTransform;
    public RectTransform mButton_03_RectTransform;
    public RectTransform mButton_04_RectTransform;
    public RectTransform mButton_05_RectTransform;
    public TextMeshProUGUI mButton_01_Text;
    public TextMeshProUGUI mButton_02_Text;
    public TextMeshProUGUI mButton_03_Text;
    public TextMeshProUGUI mButton_04_Text;
    public TextMeshProUGUI mButton_05_Text;

    public  Schriftverwalter mSchriftverwalter;

    private readonly string K_NOTIBUTTON_ERSTE_TEIL = "<b>Überschrift</b>\t\t\t\t17.12.2024\n";
    private readonly string K_NOTIBUTTON_ZWEITE_TEIL = "<size=80%>Text von der Notiz\t\t\t";
    private readonly string K_NOTIBUTTON_DRITTE_TEIL = "<size=100%>\t\tLöschen";

    void Start()
    {
        Initialisiere();
    }

    public override void Initialisiere()
    {
        base.Initialisiere();

        mInputFieldUeberschriften_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.40f);
        mInputFieldUeberschriften_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight * 0.16f);

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

        mButton_AuswahlFarbeUndSchrift_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.08333f);
        mButton_AuswahlFarbeUndSchrift_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight * 0.41f);

        mButton_01_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.1f);
        mButton_01_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight * 0.33f);
        mButton_02_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.1f);
        mButton_02_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight * 0.23f);
        mButton_03_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.1f);
        mButton_03_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight * 0.13f);
        mButton_04_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.1f);
        mButton_04_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight * 0.03f);
        mButton_05_RectTransform.sizeDelta = new Vector2(mRelevanteBreiteEineNotiz, mScreenHeight * 0.1f);
        mButton_05_RectTransform.anchoredPosition = new Vector2(0, mScreenHeight * (-0.07f));

        mButton_AuswahlFarbeUndSchrift_Text.fontSize = mBasisSchrifthoehe * 1.15f;
        setzeLinksverschiebung(mButton_AuswahlFarbeUndSchrift_Text);
        mButton_AuswahlFarbeUndSchrift_Text.font = mSchriftverwalter.LieferFont();

        mButton_01_Text.fontSize = mBasisSchrifthoehe * 0.95f;
        mButton_01_Text.font = mSchriftverwalter.LieferFont(0);
        mButton_01_Text.text = ErmittelText(0);
        setzeLinksverschiebung(mButton_01_Text);
        setzeRechtsverschiebung(mButton_01_Text);

        mButton_02_Text.fontSize = mBasisSchrifthoehe * 0.95f;
        mButton_02_Text.text = ErmittelText(1);
        mButton_02_Text.font = mSchriftverwalter.LieferFont(1);
        setzeLinksverschiebung(mButton_02_Text);
        setzeRechtsverschiebung(mButton_02_Text);

        mButton_03_Text.fontSize = mBasisSchrifthoehe * 0.95f;
        mButton_03_Text.font = mSchriftverwalter.LieferFont(2);
        mButton_03_Text.text = ErmittelText(2);
        setzeLinksverschiebung(mButton_03_Text);
        setzeRechtsverschiebung(mButton_03_Text);

        mButton_04_Text.fontSize = mBasisSchrifthoehe * 0.95f;
        mButton_04_Text.font = mSchriftverwalter.LieferFont(3);
        mButton_04_Text.text =ErmittelText(3);
        setzeLinksverschiebung(mButton_04_Text);
        setzeRechtsverschiebung(mButton_04_Text);

        mButton_05_Text.fontSize = mBasisSchrifthoehe * 0.95f;
        mButton_05_Text.font = mSchriftverwalter.LieferFont(4);
        mButton_05_Text.text = ErmittelText(4);
        setzeLinksverschiebung(mButton_05_Text);
        setzeRechtsverschiebung(mButton_05_Text);
}

    private string ErmittelText(int pVersion)
    {
        return K_NOTIBUTTON_ERSTE_TEIL + K_NOTIBUTTON_ZWEITE_TEIL + mSchriftverwalter.LieferFarbe(pVersion) + K_NOTIBUTTON_DRITTE_TEIL;
    }
}
