using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnselectCamera : MonoBehaviour
{
  [SerializeField] StateManager state;

  public void OnClick()
  {
    var cam = state.cameras[state.selectedCamera];
    cam.transform.Find("Camera").GetComponent<Camera>().enabled = false;
    //cam.transform.Find("cameraviewvolume").gameObject.SetActive(false);
    state.selectedCamera = null;
  }
}
