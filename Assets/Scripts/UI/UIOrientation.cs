using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrientation : MonoBehaviour
{
  private Camera target;
  private string label;
  private Entity entity;
  private StateManager state;
  private int currentFrame;

  void Start()
  {
    target = Camera.main;
    state = GameObject.Find("StateManager").GetComponent<StateManager>();
    label = transform.root.name;
    entity = state.entities[label];
    transform.Find("Label").GetComponent<TMPro.TextMeshProUGUI>().text = label;
  }

  void Update()
  {
    if (state.showNameplates)
    {
      currentFrame = state.currentFrame < state.totalFrames ? state.currentFrame : state.currentFrame - 1;
      transform.position = entity.keyframeTransformations[currentFrame].positionBody;
      transform.Translate(0.0f, 0.3f, 0.0f);
      transform.LookAt(target.transform);
      transform.Rotate(0.0f, 180.0f, 0.0f);
    }
  }
}
