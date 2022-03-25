using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StateManager : MonoBehaviour
{
  [SerializeField] private GameObject CameraPrefab;
  [SerializeField] private GameObject EntityPrefab;
  [SerializeField] private GameObject P;
  [SerializeField] private GameObject B;

  public string[] files;

  public Dictionary<string, GameObject> cameras;
  public Dictionary<string, Entity> entities;
  public Dictionary<string, GameObject> entityInstances;

  public int totalEntities;
  public int totalFrames;
  public int currentFrame;

  public string selectedEntity = null;
  public bool isCameraDetached = false;
  public bool isPaused = false;

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
    Debug.Log(totalFrames);
    Entities.PreprocessEntityData(entities, totalFrames);
    entityInstances = Entities.InstatiateEntities(entities, P);

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

      var pigeon = GameObject.Find(id) as GameObject;

      var head = pigeon.transform.Find("head");
      var body = pigeon.transform.Find("body");

      var entity = entities[id].keyframeTransformations[currentFrame];

      head.transform.position = entities[id].keyframeTransformations[currentFrame].positionHead;
      head.transform.rotation = Quaternion.Euler(-1.0f * entities[id].keyframeTransformations[currentFrame].rotationHead);
      body.transform.position = entities[id].keyframeTransformations[currentFrame].positionBody;
      body.transform.rotation = Quaternion.Euler(Vector3.Scale(entities[id].keyframeTransformations[currentFrame].rotationBody, new Vector3(0.3f, -1.0f, -1.0f)));
    }

    if (!isPaused)
    {
      currentFrame++;
    }
  }
}
