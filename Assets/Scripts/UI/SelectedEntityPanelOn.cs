using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedEntityPanelOn : MonoBehaviour
{
  [SerializeField] GameObject offPanel;

  public void OnClick()
  {
    offPanel.SetActive(true);
    gameObject.SetActive(false);
  }
}
