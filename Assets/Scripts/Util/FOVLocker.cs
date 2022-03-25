using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVLocker : MonoBehaviour
{
  public Camera camera;

  private void Update()
  {
    camera.fieldOfView = 60.0f;
  }
}
