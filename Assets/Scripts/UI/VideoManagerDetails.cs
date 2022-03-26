using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoManagerDetails : MonoBehaviour
{
  private StateManager state;
  GameObject textStart;
  GameObject textEnd;


  // Start is called before the first frame update
  void Start()
  {
    state = GameObject.Find("StateManager").GetComponent<StateManager>();
    textStart = GameObject.Find("Current Timestamp");
    textEnd = GameObject.Find("End Timestamp");

    var minutes = Mathf.FloorToInt(state.totalFrames / 100.0f / 60.0f);
    var seconds = state.totalFrames / 100 - (100 * 60 * minutes);
    var minutesStr = minutes < 10 ? $"0{minutes}" : minutes + "";
    var secondsStr = seconds < 10 ? $"0{seconds}" : seconds + "";
    textEnd.GetComponent<TMPro.TextMeshProUGUI>().text = $"{minutesStr}:{secondsStr}";
  }

  // Update is called once per frame
  void Update()
  {
    var minutes = Mathf.FloorToInt(state.currentFrame / 100.0f / 60.0f);
    var seconds = state.currentFrame / 100 - (100 * 60 * minutes);
    var minutesStr = minutes < 10 ? $"0{minutes}" : minutes + "";
    var secondsStr = seconds < 10 ? $"0{seconds}" : seconds + "";
    textStart.GetComponent<TMPro.TextMeshProUGUI>().text = $"{minutesStr}:{secondsStr}";
  }
}
