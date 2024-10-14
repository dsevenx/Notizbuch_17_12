using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotizBuchBL : MonoBehaviour
{
    private readonly string K_ALLE_IDS = "ALLE_IDS";
    Dictionary<int,NotizBuchBL_eineNotiz> mDictionaryAlleNoitzen;

    void Start()
    {
        string lAlleIDs = PlayerPrefs.GetString(K_ALLE_IDS);
    }
}
