using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnselectEntity : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] Toggle entityFrontConeToggle;
  [SerializeField] Toggle entityLeftConeToggle;
  [SerializeField] Toggle entityRightConeToggle;
  [SerializeField] Toggle entityViewStreamToggle;

  public void OnClick()
  {
    var entity = state.entityInstances[state.selectedEntity];
    entity.transform.Find("head/root/view volume").gameObject.SetActive(false);
    entity.transform.Find("head/root/view volume left eye").gameObject.SetActive(false);
    entity.transform.Find("head/root/view volume right eye").gameObject.SetActive(false);
    entity.transform.Find("head/root/Camera").GetComponent<Camera>().enabled = false;
    entity.transform.Find("head/root/Stream Camera").GetComponent<Camera>().enabled = false;
    entity.transform.Find("Canvas/ViewStream").gameObject.SetActive(false);

    state.showHeatmap = false;
    state.heatMap.SetActive(false);
    
    state.showFrontVisionCone = false;
    state.showLeftVisionCone = false;
    state.showRightVisionCone = false;

    //entityFrontConeToggle.isOn = false;
    //entityLeftConeToggle.isOn = false;
    //entityRightConeToggle.isOn = false;
    //state.entityViewConeHeatmap.isOn = false;
    //entityViewStreamToggle.isOn = false;
    
    state.entityViewConeFront.isOn = false;
    state.entityViewConeRight.isOn = false;
    state.entityViewConeLeft.isOn = false;
    state.entityViewConeHeatmap.isOn = false;
    state.entityViewConeStream.isOn = false;
    
    state.selectedEntity = null;
  }
}
