using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVLocker : MonoBehaviour
{
  public Camera camera;

  private void Start()
  {
    camera.stereoTargetEye = StereoTargetEyeMask.None;
  }
}
