using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
  private bool show;
  private string id;
  private int stepSize = 10;
  private StateManager state;
  private LineRenderer lineRenderer;

  [SerializeField] string bodyPart;

  void Start()
  {
    show = false;
    id = transform.root.name;

    lineRenderer = gameObject.AddComponent<LineRenderer>();
    lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
    lineRenderer.widthMultiplier = 0.005f;

    Gradient gradient = new Gradient();

    Color color = new Color(
      (float)Random.Range(0, 255),
      (float)Random.Range(0, 255),
      (float)Random.Range(0, 255)
    );

    gradient.SetKeys(
      new GradientColorKey[] { new GradientColorKey(color, 0.0f), new GradientColorKey(color, 1.0f) },
      new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) }
    );

    lineRenderer.colorGradient = gradient;

    state = GameObject.Find("StateManager").GetComponent<StateManager>();
  }

  void Update()
  {
    int frame = state.currentFrame;
    Entity entity = state.entities[id];

    int points = Mathf.FloorToInt(frame / stepSize);

    lineRenderer.positionCount = points;

    for (int p = 0; p < points; p++)
    {
      if (bodyPart == "HEAD")
      {
        lineRenderer.SetPosition(p, entity.keyframeTransformations[stepSize * p].positionHead);
      }
      else
      {
        lineRenderer.SetPosition(p, entity.keyframeTransformations[stepSize * p].positionBody);
      }
    }
  }
}
