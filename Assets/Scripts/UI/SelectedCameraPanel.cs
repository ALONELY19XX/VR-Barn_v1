using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCameraPanel : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] GameObject panel;

  void Update()
  {
    if (state.selectedCamera != null && state.selectedCamera != "")
    {
      panel.SetActive(true);
    }
    else
    {
      panel.SetActive(false);
    }
  }
}
