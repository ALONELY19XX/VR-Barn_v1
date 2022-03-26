using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCoveredDistance : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] Toggle toggle;

  public void OnClick()
  {
    state.showCoveredDistance = toggle.isOn;

    var entities = state.entityInstances;
    var isVisible = toggle.isOn;
    state.showCoveredDistance = isVisible;
    foreach (var entity in entities)
    {
      var coveredDistance = entity.Value.transform.Find("Canvas/Covered Distance");
      coveredDistance.gameObject.SetActive(isVisible);
    }
  }
}
