using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCamera : MonoBehaviour
{
  public void OnCameraSelection()
  {
    var state = GameObject.Find("StateManager").GetComponent<StateManager>();
    ResetPreviousSelection();
    state.selectedCamera = gameObject.name;
  }

  private void ResetPreviousSelection()
  {
    var state = GameObject.Find("StateManager").GetComponent<StateManager>();
    if (state.selectedCamera != null && state.selectedCamera != "")
    {
      var cam = state.cameras[state.selectedCamera];
      cam.transform.Find("Camera").gameObject.GetComponent<Camera>().enabled = false;
    }
  }
}
