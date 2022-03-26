using UnityEngine;
using UnityEngine.UI;

public class ShowNameplates : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] Toggle toggle;

  public void OnToggle()
  {
    var entities = state.entityInstances;
    var isVisible = toggle.isOn;
    state.showNameplates = isVisible;

    foreach (var entity in entities)
    {
      var nameplate = entity.Value.transform.Find("Canvas/Nameplate");
      nameplate.gameObject.SetActive(isVisible);
    }
  }
}
