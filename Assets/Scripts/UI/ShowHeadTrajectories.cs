using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHeadTrajectories : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] Toggle toggle;

  public void OnClick()
  {
    state.showHeadTrajectories = toggle.isOn;
  }
}
