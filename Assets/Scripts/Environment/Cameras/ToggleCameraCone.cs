using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCameraCone : MonoBehaviour
{
    [SerializeField] private StateManager state;
    [SerializeField] private Toggle toggle;

    public void OnToggleCameraCone()
    {
        var currentCamId = state.selectedCamera;

        var coneObj = state.cameraConeInstances[currentCamId];
        coneObj.SetActive(toggle.isOn);
    }
}
