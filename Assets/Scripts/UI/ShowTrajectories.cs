using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTrajectories : MonoBehaviour
{
  [SerializeField] GameObject subMenu;
  [SerializeField] StateManager state;
  [SerializeField] Toggle toggle;
  [SerializeField] Toggle bodyTrajectoriesToggle;
  [SerializeField] Toggle headTrajectoriesToggle;
  [SerializeField] Toggle dynamicTrajectoriesToggle;

  public void OnClick()
  {
    subMenu.SetActive(toggle.isOn);

    bodyTrajectoriesToggle.isOn = false;
    headTrajectoriesToggle.isOn = false;
    dynamicTrajectoriesToggle.isOn = false;

    state.showHeadTrajectories = false;
    state.showBodyTrajectories = false;
    state.showRecentTrajectories = false;
    state.showTrajectories = toggle.isOn;
  }
}
