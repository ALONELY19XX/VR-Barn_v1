using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityIndicatorHandler : MonoBehaviour
{

  [SerializeField] VisibilityChecker ref1;
  [SerializeField] VisibilityChecker ref2;
  [SerializeField] GameObject indicator;

  void Update()
  {
    if (ref1 != null && ref2 != null)
    {
      bool isVisible1 = ref1.GetComponent<VisibilityChecker>().isVisible;
      bool isVisible2 = ref2.GetComponent<VisibilityChecker>().isVisible;
      if (isVisible1 || isVisible2)
      {
        indicator.SetActive(true);
      }
      else
      {
        indicator.SetActive(false);
      }
    }
  }
}
