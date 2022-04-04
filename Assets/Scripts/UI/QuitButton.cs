using UnityEngine;

public class QuitButton : MonoBehaviour
{
  public void OnClick()
  {
    Debug.Log("QUIT");
    Application.Quit();
  }
}
