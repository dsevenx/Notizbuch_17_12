using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Notizverwalter : MonoBehaviour
{
    public GameObject objectPrefabEineNotizBeispiel;

    public RectTransform contentTransform;

    public Aufloesungskuemmer mAufloesungskuemmer;

    public VerticalLayoutGroup mVerticalLayoutGroup;

    public NotizBuchBL mNotizBuchBL;

    public Boolean mBildaktualisiert = false;

    void Start()
    {
        mBildaktualisiert = false;
    }
    void Update()
    {
        if (mAufloesungskuemmer.IstFertig() && mNotizBuchBL.istEingelesen() && !mBildaktualisiert)
        {
            foreach (Transform child in contentTransform)
            {
                Destroy(child.gameObject);
            }
            
            foreach (KeyValuePair<int, NotizBuchBL_eineNotiz> lKeyValuePair in mNotizBuchBL.mDictionaryAlleNotizen)
            {
                GameObject newObjectVonEineNoitz = Instantiate(objectPrefabEineNotizBeispiel);

                newObjectVonEineNoitz.transform.SetParent(contentTransform);

                newObjectVonEineNoitz.transform.localScale = Vector3.one; // Skalierung auf 1 setzen
                newObjectVonEineNoitz.transform.localPosition = Vector3.zero; // Position zurücksetzen
                newObjectVonEineNoitz.transform.localRotation = Quaternion.identity; // Rotation zurücksetzen

                newObjectVonEineNoitz.name = "NotizInstanz_" + lKeyValuePair.Key;

                EineNotiz lEineNotizAufUebersichtsbild = newObjectVonEineNoitz.GetComponent<EineNotiz>();

                lEineNotizAufUebersichtsbild.Initialisiere(mAufloesungskuemmer.mRelevanteBreiteEineNotiz,
                mAufloesungskuemmer.mRelevanteHoeheEineNotiz,
                mAufloesungskuemmer.mBasisTextverschiebung,
                mAufloesungskuemmer.mRelevanteBreiteEineNotizAnker,
                mAufloesungskuemmer.mBasisSchrifthoehe,
                lKeyValuePair.Value.GetUebeschrift(),
                lKeyValuePair.Value.GetDatum(),
                lKeyValuePair.Value.GetText(),this,lKeyValuePair.Key
                );

                mVerticalLayoutGroup.spacing = mAufloesungskuemmer.mAbstandzwischenNotizen;
            }

            mBildaktualisiert=true;
        }
    }

    public void LoadSceneEineNotiz()
    {
        mNotizBuchBL.NeueNotiz();
        SceneManager.LoadScene("EineNotiz");
    }

    public void LoadSceneEinstellungen()
    {
        SceneManager.LoadScene("Einstellungen");
    }
    internal void KlickeLoeschen(int pID)
    {
       mNotizBuchBL.LoescheNotiz(pID);
       mBildaktualisiert=false;
    }

    internal void KlickeBearbeiten(int pID)
    {
        mNotizBuchBL.SetzeAktiveNotiz(pID);
        SceneManager.LoadScene("EineNotiz");
    }
}
