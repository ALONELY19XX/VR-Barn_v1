using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCameraViewFront : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] Toggle toggle;

  public void OnClick()
  {
    state.showCameraVisionCone = toggle.isOn ? true : false;
    var selectedCam = state.cameras[state.selectedCamera];
    var viewVolume = selectedCam.transform.Find("cameraviewvolume");
    viewVolume.gameObject.SetActive(state.showCameraVisionCone);
  }
}
