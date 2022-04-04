using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVLocker : MonoBehaviour
{
  public Camera cam;

  private void Start()
  {
    cam.stereoTargetEye = StereoTargetEyeMask.None;
  }
}
