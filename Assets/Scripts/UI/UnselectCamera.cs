using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnselectCamera : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] private Toggle toggle;

  public void OnClick()
  {
    var cam = state.cameras[state.selectedCamera];
    cam.transform.Find("Camera").GetComponent<Camera>().enabled = false;
    cam.transform.Find("Stream Camera").GetComponent<Camera>().enabled = false;
    GameObject.Find($"Camera Cones/{cam.name}")?.SetActive(false);
    toggle.isOn = false;
    //GameObject.Find("Toggle Camera Vision Cone").GetComponent<Toggle>().isOn = false;
    //cam.transform.Find("cameraviewvolume").gameObject.SetActive(false);
    state.cameraConeToggle.isOn = false;
    state.cameraStreamToggle.isOn = false;
    state.selectedCamera = null;
    GameObject.Find("Camera Stream/Canvas")?.SetActive(false);
  }
}
