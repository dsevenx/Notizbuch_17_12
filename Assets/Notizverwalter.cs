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


    public int numberOfObjects;

    void Update()
    {
        if (mAufloesungskuemmer.IstFertig() && numberOfObjects > 0)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                GameObject newObjectVonEineNoitz = Instantiate(objectPrefabEineNotizBeispiel);

                newObjectVonEineNoitz.transform.SetParent(contentTransform);

                newObjectVonEineNoitz.transform.localScale = Vector3.one; // Skalierung auf 1 setzen
                newObjectVonEineNoitz.transform.localPosition = Vector3.zero; // Position zurücksetzen
                newObjectVonEineNoitz.transform.localRotation = Quaternion.identity; // Rotation zurücksetzen

                newObjectVonEineNoitz.name = "NotizInstanz_" + i;

                EineNotiz lEineNoitzBeispiel = newObjectVonEineNoitz.GetComponent<EineNotiz>();

                lEineNoitzBeispiel.Initialisiere(mAufloesungskuemmer.mRelevanteBreiteEineNotiz,
                mAufloesungskuemmer.mRelevanteHoeheEineNotiz,
                mAufloesungskuemmer.mBasisTextverschiebung,
                mAufloesungskuemmer.mRelevanteBreiteEineNotizAnker,
                mAufloesungskuemmer.mBasisSchrifthoehe
                );

                mVerticalLayoutGroup.spacing = mAufloesungskuemmer.mAbstandzwischenNotizen;
            }

            numberOfObjects=0;
        }
    }

    public void LoadSceneEineNotiz()
    {
        SceneManager.LoadScene("EineNotiz");
    }
}
