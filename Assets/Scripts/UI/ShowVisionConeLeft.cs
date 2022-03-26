using UnityEngine;
using UnityEngine.UI;

public class ShowVisionConeLeft : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] Toggle toggle;

  public void OnClick()
  {
    state.showLeftVisionCone = toggle.isOn ? true : false;
    var selectedEntity = state.entityInstances[state.selectedEntity];
    var viewVolume = selectedEntity.transform.Find("head/root/view volume left eye");
    viewVolume.gameObject.SetActive(state.showLeftVisionCone);
  }
}