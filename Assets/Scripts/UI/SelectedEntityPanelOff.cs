using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedEntityPanelOff : MonoBehaviour
{
  [SerializeField] GameObject onPanel;

  public void OnClick()
  {
    onPanel.SetActive(true);
    gameObject.SetActive(false);
  }
}
