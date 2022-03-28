using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePigeonViewStream : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] Toggle toggle;

  public void OnClick()
  {
    if (state.selectedEntity != null && state.selectedEntity != "")
    {
      var entity = state.entityInstances[state.selectedEntity];
      if (toggle.isOn)
      {
        entity.transform.Find("head/root/Stream Camera").GetComponent<Camera>().enabled = true;
        entity.transform.Find("Canvas/ViewStream").gameObject.SetActive(true);
      }
      else
      {
        entity.transform.Find("head/root/Stream Camera").GetComponent<Camera>().enabled = false;
        entity.transform.Find("Canvas/ViewStream").gameObject.SetActive(false);
      }
    }
  }
}
