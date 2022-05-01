using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentChanger : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Dropdown dropdown;
    [SerializeField] private StateManager state;
    [SerializeField] private GameObject barnEnv;
    [SerializeField] private GameObject natureEnv;

    [SerializeField] private GameObject topDownView;
    
    public void OnEnvironmentChange(int index)
    {
        // barn env selected
        if (dropdown.value == 0)
        {
            SwitchToBarnEnv();
        }
        // nature env selected
        else if (dropdown.value == 1)
        {
           SwitchToNatureEnv();
        }
    }

    private void SwitchToBarnEnv()
    {
        barnEnv.SetActive(true);
        natureEnv.SetActive(false);
        state.selectedEnvId = 0;
        UnselectCertainStuff();
        ToggleEnvSpecificElements();
    }

    private void SwitchToNatureEnv()
    {
        barnEnv.SetActive(false);
        natureEnv.SetActive(true);
        state.selectedEnvId = 1;
        UnselectCertainStuff();
        ToggleEnvSpecificElements();
    }

    public void ToggleEnvSpecificElements()
    {
        topDownView.SetActive(state.selectedEnvId == 0);
    }

    private void UnselectCertainStuff()
    {
        var selectedCam = state.selectedCamera;
        if (selectedCam != null && selectedCam != "")
        {
            GameObject.Find($"Camera Cones/{selectedCam}")?.SetActive(false);
            GameObject.Find($"Camera Stream/Canvas")?.SetActive(false);
        }

        state.selectedCamera = null;
    }
}
