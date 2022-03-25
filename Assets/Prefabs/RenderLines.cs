using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderLines : MonoBehaviour
{
  public Color c1 = Color.yellow;
  public Color c2 = Color.red;

  public GameObject head;
  public GameObject body;

  // Start is called before the first frame update
  void Start()
  {
    LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
    lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
    lineRenderer.widthMultiplier = 0.005f;
    lineRenderer.positionCount = 2;

    float alpha = 1.0f;
    Gradient gradient = new Gradient();
    gradient.SetKeys(
      new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
      new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
    );
    lineRenderer.colorGradient = gradient;
  }

  // Update is called once per frame
  void Update()
  {
    LineRenderer lineRenderer = GetComponent<LineRenderer>();
    lineRenderer.SetPosition(0, head.transform.position);
    lineRenderer.SetPosition(1, body.transform.position);
  }
}
