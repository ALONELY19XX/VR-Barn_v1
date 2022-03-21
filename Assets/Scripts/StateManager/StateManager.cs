using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StateManager : MonoBehaviour
{
  [SerializeField] private GameObject CameraPrefab;
  [SerializeField] private GameObject EntityPrefab;

  public string[] files;

  public Dictionary<string, GameObject> cameras;
  public Dictionary<string, Entity> entities;
  public Dictionary<string, GameObject> entityInstances;

  public int totalEntities;
  public int totalFrames;
  public int currentFrame;

  void Start()
  {
    Init();
  }

  private void Init()
  {
    files = Files.GetAllDataFiles();
    cameras = Cameras.Init(CameraPrefab);
    totalEntities = Entities.GetTotalEntities(files[0]);
    entities = Entities.Load(files[0], totalEntities);
    totalFrames = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, Constants.MOTION_DATA_DIR, files[0])).Length - 5;
    Entities.PreprocessEntityData(entities, totalFrames);
    entityInstances = Entities.InstatiateEntities(entities, EntityPrefab);

    InvokeRepeating("Tick", 0.0f, 0.01f);
  }

  private void Tick()
  {
    if (currentFrame >= totalFrames)
    {
      currentFrame = 0;
    }
    foreach (var entityInstance in entityInstances)
    {
      var id = entityInstance.Key;

      var head = entityInstance.Value.transform.Find("Head");
      var body = entityInstance.Value.transform.Find("Body");

      head.transform.position = entities[id].keyframeTransformations[currentFrame].positionHead;
      body.transform.position = entities[id].keyframeTransformations[currentFrame].positionBody;
      head.transform.rotation = Quaternion.Euler(entities[id].keyframeTransformations[currentFrame].rotationHead);
      body.transform.rotation = Quaternion.Euler(entities[id].keyframeTransformations[currentFrame].rotationBody);
    }

    currentFrame++;
  }
}
