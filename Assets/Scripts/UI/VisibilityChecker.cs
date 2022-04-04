using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityChecker : MonoBehaviour
{
  private StateManager state;
  [SerializeField] GameObject visibilityIndicator;

  void Awake()
  {
    state = GameObject.Find("StateManager").GetComponent<StateManager>();
  }

  void Update()
  {
    if (state != null && state.selectedEntity != null && state.selectedEntity != "")
    {
      Camera selectedEntityCamera = state.entityInstances[state.selectedEntity].transform.Find("head/root/Camera").GetComponent<Camera>();
      Vector3 viewportCoordinates = selectedEntityCamera.WorldToViewportPoint(transform.position);
      bool isVisibleToSelectedEntity = isWithinViewport(viewportCoordinates);
      if (isVisibleToSelectedEntity)
      {
        visibilityIndicator.SetActive(true);
      }
      else
      {
        visibilityIndicator.SetActive(false);
      }
    }
    else
    {
      visibilityIndicator.SetActive(false);
    }
  }

  private bool isWithinViewport(Vector3 viewportCoordinates)
  {
    return !(viewportCoordinates.x > 1.0f || viewportCoordinates.x < 0.0f || viewportCoordinates.y > 1.0f || viewportCoordinates.y < 0.0f) && viewportCoordinates.z > 0.0f;
  }
}
