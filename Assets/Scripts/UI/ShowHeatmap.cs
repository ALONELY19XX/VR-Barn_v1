using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHeatmap : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] Canvas heatmap;
  [SerializeField] Toggle toggle;

  public void OnToggle()
  {
    if (toggle.isOn)
    {
      ToggleHeatmapOn();
    }
    else
    {
      ToggleHeatmapOff();
    }
  }

  void ToggleHeatmapOn()
  {
    var entity = state.selectedEntity;
    var gradient = heatmap.GetComponent<Heatmap>().gradient;
    var tileInstances = state.tileInstances;
    state.showHeatmap = true;
    heatmap.gameObject.SetActive(true);

    if (entity != null && entity != "")
    {
      var heatmapValues = state.heatmapDistributions[entity];
      var max = Mathf.Max(heatmapValues);
      var totalTiles = Constants.HEATMAP_COLS * Constants.HEATMAP_ROWS;
      for (var x = 0; x < totalTiles; x++)
      {
        var color = gradient.Evaluate(heatmapValues[x] / (max * 1.0f));
        color.a = 1.0f;
        tileInstances[x].GetComponent<Image>().color = color;
      }
    }
  }

  void ToggleHeatmapOff()
  {
    state.showHeatmap = false;
    heatmap.gameObject.SetActive(false);
  }
}
