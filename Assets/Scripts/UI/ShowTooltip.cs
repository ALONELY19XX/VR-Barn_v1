using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTooltip : MonoBehaviour
{
    [SerializeField] private string tooltipText;
    [SerializeField] private GameObject tooltipContainer;
    [SerializeField] private TMPro.TextMeshProUGUI text;

    public void ShowTooltipOnHoverEnter()
    {
        tooltipContainer.SetActive(true);
        text.text = tooltipText;
        Debug.Log("XDDDDDDDDD");
    }

    public void HideTooltipOnHoverExit()
    {
        text.text = "";
        tooltipContainer.SetActive(false);
    }
}
