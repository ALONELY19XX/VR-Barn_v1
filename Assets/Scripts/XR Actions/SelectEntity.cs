using UnityEngine;

public class SelectEntity : MonoBehaviour
{
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
    }
  }
}
