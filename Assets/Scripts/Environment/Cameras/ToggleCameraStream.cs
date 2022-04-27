using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCameraStream : MonoBehaviour
{
    [SerializeField] private StateManager state;
    [SerializeField] private Toggle toggle;
    [SerializeField] private GameObject streamView;

    private Vector3 offset = new Vector3(0.0f, 1.0f, 0.0f);
    
    public void OnToggle()
    {
        streamView.SetActive(toggle.isOn);
        var cameraObj = state.cameras[state.selectedCamera];
        var streamingCam = cameraObj.transform.Find("Stream Camera");
        streamingCam.GetComponent<Camera>().enabled = toggle.isOn;
        var pos = cameraObj.transform.position + offset;

        streamView.transform.position = pos;
    }
}
