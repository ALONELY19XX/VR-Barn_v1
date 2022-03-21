using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatmapRenderer : MonoBehaviour
{
  // int[,] tiles = new int[Constants.HEATMAP_ROWS, Constants.HEATMAP_COLS];
  // public GameObject TilePrefab;

  // int tilesTotal = Constants.HEATMAP_COLS * Constants.HEATMAP_ROWS;

  // private Color low = Color.black;
  // private Color high = Color.cyan;

  // GameObject State;

  // float gridStartX = -3.265f;
  // float gridEndX = 3.265f;
  // float gridStartZ = -7.3f;
  // float gridEndZ = 7.3f;

  // void Awake()
  // {
  //   State = GameObject.Find("TEST");
  //   Debug.Log(State.name);
  // }

  // void Start()
  // {
  //   var grid = GameObject.Find("Canvas");
  //   Debug.Log(State.name);
  //   var entity = State.GetComponent<StateManager>().entities[0];
  //   var frames = State.GetComponent<StateManager>().entitiyFileData.totalLines - 5;
  //   Debug.Log(entity.ID);

  //   foreach (var trans in entity.keyframeTransformations.Values)
  //   {
  //     var bodyX = trans.xPositionBody;
  //     var bodyZ = trans.zPositionBody;

  //     // var lerpX = Mathf.Lerp(gridStartX, gridEndX, bodyX);
  //     // var lerpZ = Mathf.Lerp(gridStartZ, gridEndZ, bodyZ);
  //     var lerpX = Mathf.Abs(bodyX + gridEndX) / (2 * gridEndX);
  //     var lerpZ = Mathf.Abs(bodyZ + gridEndZ) / (2 * gridEndZ);

  //     Debug.Log(lerpX + " * " + Constants.HEATMAP_ROWS + " = " + (lerpX * Constants.HEATMAP_ROWS));
  //     Debug.Log(lerpZ + " * " + Constants.HEATMAP_COLS + " = " + (lerpZ * Constants.HEATMAP_COLS));

  //     var r = Mathf.RoundToInt(lerpX * Constants.HEATMAP_ROWS);
  //     var c = Mathf.RoundToInt(lerpZ * Constants.HEATMAP_COLS);

  //     try
  //     {

  //       tiles[c, r] += 1;
  //     }
  //     catch
  //     {
  //       Debug.Log(c + ", " + r);
  //     }
  //   }

  //   for (int i = 0; i < Constants.HEATMAP_COLS; i++)
  //   {
  //     for (int j = 0; j < Constants.HEATMAP_ROWS; j++)
  //     {
  //       try
  //       {

  //         var tile = Instantiate(TilePrefab);
  //         var image = tile.GetComponent<Image>();
  //         var color = Color.Lerp(Color.white, Color.magenta, tiles[j, i] / (frames * 1.0f));
  //         //image.color = Color.Lerp(Color.black, Color.cyan, Random.Range(0.0f, 1.0f));
  //         color.a = 0.2f;
  //         image.color = color;
  //         tile.transform.SetParent(grid.transform, false);
  //       }
  //       catch
  //       {
  //         Debug.Log(i + ", " + j);
  //       }
  //     }
  //   }
  // }

  // // Update is called once per frame
  // void Update()
  // {
  //   var grid = GameObject.Find("Canvas");
  //   var entity = State.GetComponent<StateManager>().entities[0];
  //   var frames = State.GetComponent<StateManager>().entitiyFileData.totalLines - 5;

  //   for (int i = 0; i < Constants.HEATMAP_COLS; i++)
  //   {
  //     for (int j = 0; j < Constants.HEATMAP_ROWS; j++)
  //     {
  //       try
  //       {
  //         var tile = grid.transform.GetChild(i * j);
  //         var image = tile.GetComponent<Image>();
  //         // var color = Color.Lerp(Color.white, Color.magenta, tiles[j, i] / (frames * 1.0f));
  //         //image.color = Color.Lerp(Color.black, Color.cyan, Random.Range(0.0f, 1.0f));
  //         //color.a = 0.2f;
  //         image.color = Color.white;
  //         //tile.transform.SetParent(grid.transform, false);
  //       }
  //       catch
  //       {

  //       }
  //     }
  //   }

  //   var trans = entity.keyframeTransformations[State.GetComponent<StateManager>().keyframe];

  //   var bodyX = trans.xPositionBody;
  //   var bodyZ = trans.zPositionBody;

  //   var lerpX = Mathf.Abs(bodyX + gridEndX) / (2 * gridEndX);
  //   var lerpZ = Mathf.Abs(bodyZ + gridEndZ) / (2 * gridEndZ);

  //   var r = Mathf.RoundToInt(lerpX * Constants.HEATMAP_ROWS);
  //   var c = Mathf.RoundToInt(lerpZ * Constants.HEATMAP_COLS);

  //   Debug.Log(grid.transform.childCount);
  //   Debug.Log(r * c);

  //   grid.transform.GetChild(r * c).GetComponent<Image>().color = Color.cyan;

  //   //tiles[c, r] += 1;
  //   // foreach (var trans in entity.keyframeTransformations.Values)
  //   // {
  //   //   var bodyX = trans.xPositionBody;
  //   //   var bodyZ = trans.zPositionBody;

  //   //   // var lerpX = Mathf.Lerp(gridStartX, gridEndX, bodyX);
  //   //   // var lerpZ = Mathf.Lerp(gridStartZ, gridEndZ, bodyZ);
  //   //   var lerpX = Mathf.Abs(bodyX + gridEndX) / (2 * gridEndX);
  //   //   var lerpZ = Mathf.Abs(bodyZ + gridEndZ) / (2 * gridEndZ);

  //   //   Debug.Log(lerpX + " * " + Constants.HEATMAP_ROWS + " = " + (lerpX * Constants.HEATMAP_ROWS));
  //   //   Debug.Log(lerpZ + " * " + Constants.HEATMAP_COLS + " = " + (lerpZ * Constants.HEATMAP_COLS));

  //   //   var r = Mathf.RoundToInt(lerpX * Constants.HEATMAP_ROWS);
  //   //   var c = Mathf.RoundToInt(lerpZ * Constants.HEATMAP_COLS);

  //   //   try
  //   //   {

  //   //     tiles[c, r] += 1;
  //   //   }
  //   //   catch
  //   //   {
  //   //     Debug.Log(c + ", " + r);
  //   //   }
  //   // }

  // }
}
