using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoveredDistance : MonoBehaviour
{
  [SerializeField] TMPro.TextMeshProUGUI label;
  [SerializeField] GameObject root;
  private string entityName;
  private Entity entity;
  private StateManager state;
  private int stepSize = 50;

  void Start()
  {
    entityName = root.name;
    state = GameObject.Find("StateManager").GetComponent<StateManager>();
    entity = state.entities[entityName];
  }

  void Update()
  {
    if (state.showCoveredDistance)
    {
      var points = Mathf.FloorToInt(state.currentFrame / stepSize);

      Vector3[] checkpoints = new Vector3[points];
      float distance = 0.0f;

      for (int x = 0; x < points; x++)
      {
        checkpoints[x] = entity.keyframeTransformations[x * stepSize].positionBody;
      }

      for (int x = 0; x < checkpoints.Length - 1; x++)
      {
        distance += Vector3.Distance(checkpoints[x], checkpoints[x + 1]);
      }

      string distanceStr = distance.ToString("n2");
      label.text = $"Travelled: {distanceStr}m";

    }
  }
}
