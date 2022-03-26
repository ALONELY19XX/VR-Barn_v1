using UnityEngine;
using UnityEngine.UI;

public class ShowVisionConeFront : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] Toggle toggle;

  public void OnClick()
  {
    state.showFrontVisionCone = toggle.isOn ? true : false;
    var selectedEntity = state.entityInstances[state.selectedEntity];
    var viewVolume = selectedEntity.transform.Find("head/root/view volume");
    viewVolume.gameObject.SetActive(state.showFrontVisionCone);
  }
}