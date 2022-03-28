using UnityEngine;

public class PlayButtonState : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] GameObject playIcon;
  [SerializeField] GameObject pauseIcon;

  // Update is called once per frame
  void Update()
  {
    if (state.isPaused)
    {
      playIcon.SetActive(true);
      pauseIcon.SetActive(false);
    }
    else
    {
      playIcon.SetActive(false);
      pauseIcon.SetActive(true);
    }
  }
}
