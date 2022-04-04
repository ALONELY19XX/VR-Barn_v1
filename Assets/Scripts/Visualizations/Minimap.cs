using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
  [SerializeField] StateManager state;
  [SerializeField] GameObject minimapEntityPrefab;
  Dictionary<string, GameObject> minimapEntities = new Dictionary<string, GameObject>();
  //float offset = 40.0f;
  Vector3 offset = new Vector3(40.0f, 0.0f, 0.0f);

  void Start()
  {
    Debug.Log(state.entities.Count);
    foreach (var entity in state.entities.Keys)
    {
      var p = Instantiate(minimapEntityPrefab, Vector3.zero, Quaternion.identity);
      p.name = entity;
      p.transform.SetParent(transform);
      minimapEntities.Add(entity, p);
    }
  }

  void Update()
  {
    foreach (var entity in minimapEntities)
    {
      //var correspondingEntity = state.entities[entity.Key];
      var correspondingEntityInstance = state.entityInstances[entity.Key];
      var head = correspondingEntityInstance.transform.Find("head/root").transform;
      var viewDir = Vector3.ProjectOnPlane(head.forward, Vector3.up);
      entity.Value.transform.forward = viewDir;
      entity.Value.transform.position = head.position + offset;
      Debug.DrawRay(entity.Value.transform.position, viewDir * 2, Color.red, 0f);
    }
  }
}
