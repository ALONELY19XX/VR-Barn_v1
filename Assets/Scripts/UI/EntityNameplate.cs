using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EntityNameplate : MonoBehaviour
{
  [SerializeField] GameObject root;
  [SerializeField] TMPro.TextMeshProUGUI label;

  void Start()
  {
    var id = root.name.Split('-').Last();
    //label.text = root.name;
    label.text = $"Pigeon-{id}";
  }
}
