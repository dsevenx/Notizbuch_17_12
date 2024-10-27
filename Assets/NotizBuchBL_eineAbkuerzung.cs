using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotizBuchBL_eineAbkuerzung
{
  private string mAbk;

  private string mAbkText;

  public NotizBuchBL_eineAbkuerzung(string pAbk, string pAbkText)
  {
    this.mAbk = pAbk;
    this.mAbkText = pAbkText;
  }

  public string getAbk()
  {
    return mAbk;
  }
  public string getAbkText()
  {
    return mAbkText;
  }
}
