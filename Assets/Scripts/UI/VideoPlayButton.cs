using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayButton : MonoBehaviour
{
  [SerializeField] StateManager state;

  public void OnClick()
  {
    state.isPaused = !state.isPaused;
  }
}
