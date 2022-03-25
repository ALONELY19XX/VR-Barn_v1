using UnityEngine;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{
  private StateManager state;
  private Slider slider;

  void Start()
  {
    state = GameObject.Find("StateManager").GetComponent<StateManager>();
    slider = gameObject.GetComponent<Slider>();
    slider.maxValue = state.totalFrames;
  }

  void Update()
  {
    slider.value = state.currentFrame;
  }

  public void OnSliderChange()
  {
    state.currentFrame = (int)slider.value;
  }
}

