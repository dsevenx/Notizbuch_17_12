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

    public Boolean mBildaktualisiert = false;

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

            mBildaktualisiert = true;
        }
    }
}
