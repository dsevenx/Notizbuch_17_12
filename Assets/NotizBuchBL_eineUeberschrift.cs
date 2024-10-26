using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotizBuchBL_eineUeberschrift
{
  private readonly string K_MAX_ID_UEBERSCHRIFT = "K_ID_UEBERSCHRIFT";

  private int mId;

  public NotizBuchBL_eineUeberschrift(int pID)
  {
    this.mId = pID;
  }

  public void SetUeberschrift(string pText)
  {
    PlayerPrefs.SetString(K_MAX_ID_UEBERSCHRIFT + this.mId, pText);
  }

  public string GetUeberschrift()
  {
    return PlayerPrefs.GetString(K_MAX_ID_UEBERSCHRIFT + this.mId);
  }


}
