using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBodyTrajectories : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] Toggle toggle;

  public void OnClick()
  {
    state.showBodyTrajectories = toggle.isOn;
  }
}
