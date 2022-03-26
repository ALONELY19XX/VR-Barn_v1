using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCanvasOrientation : MonoBehaviour
{
  private Camera target;
  [SerializeField] GameObject anchor;

  void Start()
  {
    target = Camera.main;
  }

  void Update()
  {
    transform.position = anchor.transform.position;
    transform.Translate(0.0f, 0.6f, 0.0f);
    transform.LookAt(target.transform);
    transform.Rotate(0.0f, 180.0f, 0.0f);
  }
}
