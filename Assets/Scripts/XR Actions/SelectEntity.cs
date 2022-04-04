using UnityEngine;
using UnityEngine.UI;

public class SelectEntity : MonoBehaviour
{
  Toggle entityFrontConeToggle;
  Toggle entityLeftConeToggle;
  Toggle entityRightConeToggle;
  Toggle entityViewStreamToggle;

  void Start()
  {
    entityFrontConeToggle = GameObject.Find("Toggle Vision Cone Front").GetComponent<Toggle>();
    entityLeftConeToggle = GameObject.Find("Toggle Vision Cone Left Eye").GetComponent<Toggle>();
    entityRightConeToggle = GameObject.Find("Toggle Vision Cone Right Eye").GetComponent<Toggle>();
    entityViewStreamToggle = GameObject.Find("Toggle Pigeon View Stream").GetComponent<Toggle>();
  }

  public void OnEntitySelection()
  {
    var state = GameObject.Find("StateManager").GetComponent<StateManager>();
    ResetPreviousSelection();
    state.selectedEntity = gameObject.name;
  }

  private void ResetPreviousSelection()
  {
    var state = GameObject.Find("StateManager").GetComponent<StateManager>();
    if (state.selectedEntity != null && state.selectedEntity != "")
    {
      var entity = state.entityInstances[state.selectedEntity];
      entity.transform.Find("head/root/view volume").gameObject.SetActive(false);
      entity.transform.Find("head/root/view volume left eye").gameObject.SetActive(false);
      entity.transform.Find("head/root/view volume right eye").gameObject.SetActive(false);
      entity.transform.Find("head/root/Camera").GetComponent<Camera>().enabled = false;
      entity.transform.Find("head/root/Stream Camera").GetComponent<Camera>().enabled = false;

      state.showFrontVisionCone = false;
      state.showLeftVisionCone = false;
      state.showRightVisionCone = false;

      entityFrontConeToggle.isOn = false;
      entityLeftConeToggle.isOn = false;
      entityRightConeToggle.isOn = false;
      entityViewStreamToggle.isOn = false;
    }
  }
}
