using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMinimap : MonoBehaviour
{
  [SerializeField] GameObject minimap;
  [SerializeField] GameObject onBtn;
  [SerializeField] GameObject offBtn;

  public void ShowMinimap()
  {
    minimap.SetActive(true);
    offBtn.SetActive(false);
    onBtn.SetActive(true);
  }

  public void HideMinimap()
  {
    minimap.SetActive(false);
    offBtn.SetActive(true);
    onBtn.SetActive(false);
  }
}
