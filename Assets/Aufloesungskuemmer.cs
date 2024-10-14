using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Aufloesungskuemmer : AufloesungskuemmerBase
{
    public int mRelevanteHoeheEineNotiz;

    public int mAbstandzwischenNotizen;

    void Start()
    {
        Initialisiere();
    }

    public override void Initialisiere()
    {
       base.Initialisiere();

       mAbstandzwischenNotizen = (int)(mScreenHeight * 0.005f);
      
       mRelevanteHoeheEineNotiz = (int)(mScreenHeight * 0.166f);
    }
}
