using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
  private string id;
  private int stepSize = 10;
  private StateManager state;
  private LineRenderer lineRenderer;
  [SerializeField] private Material mat;

  [SerializeField] string bodyPart;

  void Start()
  {
    id = transform.root.name;

    lineRenderer = gameObject.AddComponent<LineRenderer>();
    lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
    lineRenderer.sortingOrder = 100;
    lineRenderer.widthMultiplier = 0.01f;

    Gradient gradient = new Gradient();

    Color color = new Color(
      (float)Random.Range(0, 255) / 255.0f,
      (float)Random.Range(0, 255) / 255.0f,
      (float)Random.Range(0, 255) / 255.0f
    );

    gradient.SetKeys(
      new GradientColorKey[] { new GradientColorKey(color, 0.0f), new GradientColorKey(color, 1.0f) },
      new GradientAlphaKey[] { new GradientAlphaKey(0.1f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) }
    );

    lineRenderer.colorGradient = gradient;

    state = GameObject.Find("StateManager").GetComponent<StateManager>();
  }

  void Update()
  {
    int frame = state.currentFrame;
    Entity entity = state.entities[id];

    if (state.showTrajectories)
    {
      if (state.showRecentTrajectories)
      {
        int points;

        if (frame > 1000)
        {
          points = 100;
        }
        else
        {
          points = Mathf.FloorToInt(frame / stepSize);
        }

        var start = frame > 1000 ? frame - 1000 : 0;

        for (int p = 0; p < points; p++)
        {
          if (bodyPart == "HEAD" && state.showHeadTrajectories)
          {
            lineRenderer.positionCount = points;
            lineRenderer.SetPosition(p, entity.keyframeTransformations[start + stepSize * p].positionHead);
          }
          else if (bodyPart == "BODY" && state.showBodyTrajectories)
          {
            lineRenderer.positionCount = points;
            lineRenderer.SetPosition(p, entity.keyframeTransformations[start + stepSize * p].positionBody);
          }
          else
          {
            lineRenderer.positionCount = 0;
          }
        }
      }

      else
      {
        int points = Mathf.FloorToInt(frame / stepSize);
        for (int p = 0; p < points; p++)
        {
          if (bodyPart == "HEAD" && state.showHeadTrajectories)
          {
            lineRenderer.positionCount = points;
            lineRenderer.SetPosition(p, entity.keyframeTransformations[stepSize * p].positionHead);
          }
          else if (bodyPart == "BODY" && state.showBodyTrajectories)
          {
            lineRenderer.positionCount = points;
            lineRenderer.SetPosition(p, entity.keyframeTransformations[stepSize * p].positionBody);
          }
          else
          {
            lineRenderer.positionCount = 0;
          }
        }
      }
      //int points = Mathf.FloorToInt(frame / stepSize);
    }
    else
    {
      lineRenderer.positionCount = 0;
    }

  }
}
