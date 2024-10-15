using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotizBuchBL_eineNotiz
{
  private readonly string K_MAX_ID_UEBERSCHRIFT = "K_ID_NOTIZ_UEBER";
  private readonly string K_MAX_ID_DATUM = "K_ID_NOTIZ_DATUM";
  private readonly string K_MAX_ID_TEXT = "K_ID_NOTIZ_TEXT";

  private int mId;

  public NotizBuchBL_eineNotiz(int pID)
  {
    this.mId = pID;
  }

  public void SetText(string pText)
  {
    PlayerPrefs.SetString(K_MAX_ID_TEXT + this.mId, pText);
  }

  public string GetText()
  {
    return PlayerPrefs.GetString(K_MAX_ID_TEXT + this.mId);
  }

  public void SetDatum(string pDatum)
  {
    PlayerPrefs.SetString(K_MAX_ID_DATUM + this.mId, pDatum);
  }

  public string GetDatum()
  {
    return PlayerPrefs.GetString(K_MAX_ID_DATUM + this.mId);
  }

  public void SetUebeschrift(string pDatum)
  {
    PlayerPrefs.SetString(K_MAX_ID_UEBERSCHRIFT + this.mId, pDatum);
  }

  public string GetUebeschrift()
  {
    return PlayerPrefs.GetString(K_MAX_ID_UEBERSCHRIFT + this.mId);
  }
}
