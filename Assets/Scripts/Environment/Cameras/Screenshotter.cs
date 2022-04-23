using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshotter : MonoBehaviour
{
  [SerializeField] StateManager state;

  public void TakeScreenshot()
  {
    RenderTexture rt = new RenderTexture(1280, 720, 24);
    var selectedCam = GameObject.Find($"{state.selectedCamera}/Camera").GetComponent<Camera>();
    selectedCam.targetTexture = rt;
    Texture2D screenshot = new Texture2D(1280, 720, TextureFormat.RGB24, false);
    selectedCam.Render();
    RenderTexture.active = rt;
    screenshot.ReadPixels(new Rect(0, 0, 1280, 720), 0, 0);
    selectedCam.targetTexture = null;
    RenderTexture.active = null;
    Destroy(rt);
    byte[] bytes = screenshot.EncodeToPNG();
    var deviceId = state.selectedCamera;
    string filename = ScreenShotName(1280, 720, deviceId);
    System.IO.File.WriteAllBytes(filename, bytes);
    Debug.Log("Screenshot taken");
  }

  public static string ScreenShotName(int width, int height, string devideId)
  {
    return string.Format(Application.streamingAssetsPath + "/Screenshots/screen_{1}x{2}_{3} - deviceId .png",
                         Application.dataPath,
                         width, height,
                         System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
  }
}
