using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityNameplate : MonoBehaviour
{
  [SerializeField] GameObject root;
  [SerializeField] TMPro.TextMeshProUGUI label;

  void Start()
  {
    label.text = root.name;
  }
}
