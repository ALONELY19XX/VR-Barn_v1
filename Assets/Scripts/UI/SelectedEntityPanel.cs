using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedEntityPanel : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] GameObject panel;

  void Update()
  {
    if (state.selectedEntity != null && state.selectedEntity != "")
    {
      panel.SetActive(true);
    }
    else
    {
      panel.SetActive(false);
    }
  }
}