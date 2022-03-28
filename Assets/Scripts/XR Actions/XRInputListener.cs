using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class XRInputListener : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] InputActionReference toggleVideoPlayerAction = null;
  [SerializeField] InputActionReference toggleWallUIReference = null;

  [SerializeField] GameObject videoTrack;
  [SerializeField] GameObject wallUIs;
  [SerializeField] Camera mainCamera;

  void Awake()
  {
    toggleVideoPlayerAction.action.started += ToggleVideoPlayer;
    toggleWallUIReference.action.started += ToggleWallUI;
  }

  void OnDestroy()
  {
    toggleVideoPlayerAction.action.started -= ToggleVideoPlayer;
    toggleWallUIReference.action.started -= ToggleWallUI;
  }

  private void ToggleVideoPlayer(InputAction.CallbackContext context)
  {
    if (!state.isCameraDetached)
    {
      state.showVideoPlayer = !state.showVideoPlayer;
      //var videoPlayerUI = GameObject.Find("Video Track");
      //videoPlayerUI.SetActive(state.showVideoPlayer);
      videoTrack.SetActive(state.showVideoPlayer);
    }
    else
    {
      mainCamera.enabled = true;
      state.isCameraDetached = false;
      if (state.selectedEntity != null && state.selectedEntity != "")
      {
        state.entityInstances[state.selectedEntity].transform.Find("head/root/Camera").GetComponent<Camera>().enabled = false;
      }
      if (state.selectedCamera != null && state.selectedCamera != "")
      {
        state.cameras[state.selectedCamera].transform.Find("Camera").GetComponent<Camera>().enabled = false;
      }
    }
  }

  private void ToggleWallUI(InputAction.CallbackContext context)
  {
    state.showWallUI = !state.showWallUI;
    wallUIs.SetActive(state.showWallUI);
    // var wallUI = GameObject.Find("Wall UIs");
    // wallUI.SetActive(state.showWallUI);
  }
}
