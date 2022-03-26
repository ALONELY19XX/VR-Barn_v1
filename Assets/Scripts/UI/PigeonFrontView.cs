using UnityEngine;

public class PigeonFrontView : MonoBehaviour
{
  [SerializeField] Camera playerCamera;
  [SerializeField] StateManager state;

  public void OnClick()
  {
    var entity = state.entityInstances[state.selectedEntity];
    var camera = entity.transform.Find("head/root/Camera").GetComponent<Camera>();
    playerCamera.enabled = false;
    camera.enabled = true;
  }
}
