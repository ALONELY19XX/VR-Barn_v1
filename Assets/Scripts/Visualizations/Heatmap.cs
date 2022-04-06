using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heatmap : MonoBehaviour
{
  [SerializeField] Canvas heatmap;
  [SerializeField] GameObject tilePrefab;
  [SerializeField] StateManager state;
  public Gradient gradient;
  GameObject[] tileInstances;

  void Start()
  {
    int totalTiles = Constants.HEATMAP_ROWS * Constants.HEATMAP_COLS;
    GameObject[] tileInstances = new GameObject[totalTiles];
    for (var x = 0; x < totalTiles; x++)
    {
      var tile = Instantiate(tilePrefab);
      tileInstances[x] = tile;
      tile.transform.SetParent(heatmap.transform, false);

      // Color color = new Color(
      //   (float)Random.Range(0, 255) / 255.0f,
      //   (float)Random.Range(0, 255) / 255.0f,
      //   (float)Random.Range(0, 255) / 255.0f
      // );
      // color.a = 0.3f;

      // tile.GetComponent<Image>().color = color;
    }
    //ShowHeatmap("Entity-1", totalTiles, tileInstances);
    gameObject.SetActive(false);
    state.tileInstances = tileInstances;
  }

  void ShowHeatmap(string entity, int totalTiles, GameObject[] tileInstances)
  {
    Debug.Log(state.heatmapDistributions.Keys.Count);
    var heatmapValues = state.heatmapDistributions[entity];
    var max = Mathf.Max(heatmapValues);
    for (var x = 0; x < totalTiles; x++)
    {

      //var color = Color.Lerp(new Color32(0x44, 0x04, 0x56, 255), new Color32(234, 229, 40, 255), heatmapValues[x] / (max * 1.0f));
      var color = gradient.Evaluate(heatmapValues[x] / (max * 1.0f));
      color.a = 1.0f;
      tileInstances[x].GetComponent<Image>().color = color;
    }
  }
}
