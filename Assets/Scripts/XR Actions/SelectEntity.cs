using UnityEngine;

public class SelectEntity : MonoBehaviour
{
  public void OnEntitySelection()
  {
    var state = GameObject.Find("StateManager").GetComponent<StateManager>();
    state.selectedEntity = gameObject.name;
    Debug.Log(state.selectedEntity);
  }

  public void OnHoverEntityEnter()
  {
    var outline = gameObject.GetComponent<Outline>();
    Debug.Log("XDDD");
    outline.OutlineWidth = 6.0f;
  }

  public void OnHoverEntityLeave()
  {
    var outline = gameObject.GetComponent<Outline>();
    outline.OutlineWidth = 0.0f;
  }
}
