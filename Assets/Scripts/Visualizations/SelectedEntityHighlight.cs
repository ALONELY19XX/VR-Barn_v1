using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedEntityHighlight : MonoBehaviour
{
  [SerializeField] Outline outline;
  private StateManager state;

  void Start()
  {
    state = GameObject.Find("StateManager").GetComponent<StateManager>();
  }

  void Update()
  {
    if (state.selectedEntity == gameObject.name)
    {
      outline.enabled = true;
    }
    else
    {
      outline.enabled = false;
    }
  }
}
