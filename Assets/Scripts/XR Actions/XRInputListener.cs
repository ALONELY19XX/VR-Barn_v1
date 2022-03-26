using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class XRInputListener : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] InputActionReference toggleVideoPlayerAction = null;
  [SerializeField] InputActionReference toggleWallUIReference = null;

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
    state.showVideoPlayer = !state.showVideoPlayer;
    var videoPlayerUI = GameObject.Find("HUD/Video Track");
    videoPlayerUI.SetActive(state.showVideoPlayer);
  }

  private void ToggleWallUI(InputAction.CallbackContext context)
  {
    state.showWallUI = !state.showWallUI;
    var wallUI = GameObject.Find("Wall UIs");
    wallUI.SetActive(state.showWallUI);
  }
}
