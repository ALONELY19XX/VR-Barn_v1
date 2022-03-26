using UnityEngine;
using UnityEngine.UI;

public class ShowVisionConeRight : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] Toggle toggle;

  public void OnClick()
  {
    state.showRightVisionCone = toggle.isOn ? true : false;
    var selectedEntity = state.entityInstances[state.selectedEntity];
    var viewVolume = selectedEntity.transform.Find("head/root/view volume right eye");
    viewVolume.gameObject.SetActive(state.showRightVisionCone);
  }
}