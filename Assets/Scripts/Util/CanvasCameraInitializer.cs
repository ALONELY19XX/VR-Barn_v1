using UnityEngine;
using UnityEngine.UI;

public class CanvasCameraInitializer : MonoBehaviour
{
  [SerializeField] Canvas canvas;

  void Awake()
  {
    canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
  }
}
