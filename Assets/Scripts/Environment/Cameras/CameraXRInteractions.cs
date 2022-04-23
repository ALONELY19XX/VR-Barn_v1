using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraXRInteractions : MonoBehaviour
{
  [SerializeField] GameObject canvas;

  public void OnHoverEnter()
  {
    canvas.SetActive(true);
  }

  public void OnHoverLeave()
  {
    canvas.SetActive(false);
  }
}
