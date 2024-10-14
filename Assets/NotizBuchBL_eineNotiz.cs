using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotizBuchBL_eineNotiz
{
  private readonly string K_MAX_ID_UEBERSCHRIFT = "K_ID_NOTIZ_UEBER";
  private readonly string K_MAX_ID_DATUM = "K_ID_NOTIZ_DATUM";
  private readonly string K_MAX_ID_TEXT = "K_ID_NOTIZ_TEXT";

  int mId;

  public NotizBuchBL_eineNotiz(int pID)
  {
    this.mId = pID;
  }

  public setText(string pText)
  {
    PlayerPrefs.SetString(K_MAX_ID_TEXT + this.mId, pText);
  }

  public GetText()
  {
    return PlayerPrefs.GetString(K_MAX_ID_TEXT + this.mId);
  }

  public setDatum(string pDatum)
  {
    PlayerPrefs.SetString(K_MAX_ID_DATUMT + this.mId, pDatum);
  }

  public GetDatum()
  {
    return PlayerPrefs.GetString(K_MAX_ID_DATUM + this.mId);
  }

  public setUebeschrift(string pDatum)
  {
    PlayerPrefs.SetString(K_MAX_ID_UEBERSCHRIFT + this.mId, pDatum);
  }

  public GetUebeschrif()
  {
    return PlayerPrefs.GetString(K_MAX_ID_UEBERSCHRIFT + this.mId);
  }
}
