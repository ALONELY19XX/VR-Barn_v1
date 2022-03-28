using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFrontView : MonoBehaviour
{
  [SerializeField] Camera playerCamera;
  [SerializeField] StateManager state;

  public void OnClick()
  {
    var cam = state.cameras[state.selectedCamera];
    state.isCameraDetached = true;
    var camera = cam.transform.Find("Camera").GetComponent<Camera>();
    playerCamera.enabled = false;
    camera.enabled = true;
  }
}
