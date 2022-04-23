using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCanvasOrientation : MonoBehaviour
{
  [SerializeField] Transform root;
  Vector3 offset = new Vector3(0.0f, -0.5f, 0.0f);

  void Update()
  {
    transform.position = root.position;
    transform.Translate(offset);
    transform.LookAt(Camera.main.transform);
  }
}
