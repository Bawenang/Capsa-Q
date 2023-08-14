using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CongratulationDialogView : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI descriptionText;
    
    public void SetWinnerName(string winnerName)
    {
        descriptionText.text = winnerName + " is the winner.";
    }
}
