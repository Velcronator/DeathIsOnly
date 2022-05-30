using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInfo : MonoBehaviour
{
    public Text blueCount, yellowCount, redCount, purpleCount, totalCount;

    public void upDateTxtFields(string pBlueCountTxt, string pYellowCountTxt, string pRedCountTxt, string pPurpleCountTxt, string pTotalCountTxt)
    {
        blueCount.text = pBlueCountTxt;
        yellowCount.text = pYellowCountTxt;
        redCount.text = pRedCountTxt;
        purpleCount.text = pPurpleCountTxt;
        totalCount.text = pTotalCountTxt;
    }

}
