using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotizBuchBL_eineAbkuerzung
{
  private readonly string K_MAX_ID_ABK = "K_ID_ABK";

  private int mId;

  public NotizBuchBL_eineAbkuerzung(int pID)
  {
    this.mId = pID;
  }

  public void SetAbkText(string pText)
  {
    PlayerPrefs.SetString(K_MAX_ID_ABK + this.mId, pText);
  }

  public string GetAbkText()
  {
    return PlayerPrefs.GetString(K_MAX_ID_ABK + this.mId);
  }


}
