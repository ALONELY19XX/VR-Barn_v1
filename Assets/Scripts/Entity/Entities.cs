using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;

public static class Entities
{
  public static int GetTotalEntities(string file)
  {
    string path = Path.Combine(Application.streamingAssetsPath, Constants.MOTION_DATA_DIR, file);
    string header = File.ReadAllLines(path)[Constants.HEADER_TITLES_OFFSET];
    string[] titles = header.Split(',');
    return (titles.Length - Constants.ROW_OFFSET) / Constants.ENTITY_PADDING_TOTAL;
  }

  public static Dictionary<string, GameObject> InstatiateEntities(Dictionary<string, Entity> entities, GameObject entityModel)
  {
    Dictionary<string, GameObject> entityInstances = new Dictionary<string, GameObject>();

    foreach (var entity in entities)
    {
      GameObject entityInstance = GameObject.Instantiate(entityModel);
      entityInstance.name = entity.Value.ID;
      entityInstances[entityInstance.name] = entityInstance;
    }

    return entityInstances;
  }

  public static Dictionary<string, Entity> Load(string file, int totalEntities)
  {
    Entity[] entitiesArr = new Entity[totalEntities];

    string[] frames = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, Constants.MOTION_DATA_DIR, file));
    int totalFrames = frames.Length;

    for (int idx = 0; idx < totalEntities; idx++)
    {
      string entityId = $"Entity-{idx}";
      entitiesArr[idx] = new Entity(entityId);
    }

    for (int frame = Constants.HEADER_OFFSET; frame < totalFrames; frame++)
    {

      string[] frameValues = frames[frame].Split(',');

      for (int e = 0; e < totalEntities; e++)
      {
        string xRotHeadRaw = frameValues[Constants.ROW_OFFSET + e * Constants.ENTITY_PADDING_TOTAL + 2];
        string yRotHeadRaw = frameValues[Constants.ROW_OFFSET + e * Constants.ENTITY_PADDING_TOTAL + 0];
        string zRotHeadRaw = frameValues[Constants.ROW_OFFSET + e * Constants.ENTITY_PADDING_TOTAL + 1];
        float xRotHead = string.IsNullOrEmpty(xRotHeadRaw) ? float.PositiveInfinity : float.Parse(xRotHeadRaw, CultureInfo.InvariantCulture) * Mathf.Rad2Deg;
        float yRotHead = string.IsNullOrEmpty(yRotHeadRaw) ? float.PositiveInfinity : float.Parse(yRotHeadRaw, CultureInfo.InvariantCulture) * Mathf.Rad2Deg;
        float zRotHead = string.IsNullOrEmpty(zRotHeadRaw) ? float.PositiveInfinity : float.Parse(zRotHeadRaw, CultureInfo.InvariantCulture) * Mathf.Rad2Deg;

        string xRotBodyRaw = frameValues[Constants.ROW_OFFSET + e * Constants.ENTITY_PADDING_TOTAL + 8];
        string yRotBodyRaw = frameValues[Constants.ROW_OFFSET + e * Constants.ENTITY_PADDING_TOTAL + 6];
        string zRotBodyRaw = frameValues[Constants.ROW_OFFSET + e * Constants.ENTITY_PADDING_TOTAL + 7];
        float xRotBody = string.IsNullOrEmpty(xRotBodyRaw) ? float.PositiveInfinity : float.Parse(xRotBodyRaw, CultureInfo.InvariantCulture) * Mathf.Rad2Deg;
        float yRotBody = string.IsNullOrEmpty(yRotBodyRaw) ? float.PositiveInfinity : float.Parse(yRotBodyRaw, CultureInfo.InvariantCulture) * Mathf.Rad2Deg;
        float zRotBody = string.IsNullOrEmpty(zRotBodyRaw) ? float.PositiveInfinity : float.Parse(zRotBodyRaw, CultureInfo.InvariantCulture) * Mathf.Rad2Deg;

        string xPosHeadRaw = frameValues[Constants.ROW_OFFSET + e * Constants.ENTITY_PADDING_TOTAL + 3];
        string yPosHeadRaw = frameValues[Constants.ROW_OFFSET + e * Constants.ENTITY_PADDING_TOTAL + 5];
        string zPosHeadRaw = frameValues[Constants.ROW_OFFSET + e * Constants.ENTITY_PADDING_TOTAL + 4];
        float xPosHead = string.IsNullOrEmpty(xPosHeadRaw) ? float.PositiveInfinity : float.Parse(xPosHeadRaw, CultureInfo.InvariantCulture) / 1000.0f;
        float yPosHead = string.IsNullOrEmpty(yPosHeadRaw) ? float.PositiveInfinity : float.Parse(yPosHeadRaw, CultureInfo.InvariantCulture) / 1000.0f;
        float zPosHead = string.IsNullOrEmpty(zPosHeadRaw) ? float.PositiveInfinity : float.Parse(zPosHeadRaw, CultureInfo.InvariantCulture) / 1000.0f;

        string xPosBodyRaw = frameValues[Constants.ROW_OFFSET + e * Constants.ENTITY_PADDING_TOTAL + 9];
        string yPosBodyRaw = frameValues[Constants.ROW_OFFSET + e * Constants.ENTITY_PADDING_TOTAL + 11];
        string zPosBodyRaw = frameValues[Constants.ROW_OFFSET + e * Constants.ENTITY_PADDING_TOTAL + 10];
        float xPosBody = string.IsNullOrEmpty(xPosBodyRaw) ? float.PositiveInfinity : float.Parse(xPosBodyRaw, CultureInfo.InvariantCulture) / 1000.0f;
        float yPosBody = string.IsNullOrEmpty(yPosBodyRaw) ? float.PositiveInfinity : float.Parse(yPosBodyRaw, CultureInfo.InvariantCulture) / 1000.0f;
        float zPosBody = string.IsNullOrEmpty(zPosBodyRaw) ? float.PositiveInfinity : float.Parse(zPosBodyRaw, CultureInfo.InvariantCulture) / 1000.0f;

        entitiesArr[e].keyframeTransformations[frame - 5] = new EntityTransformation(xRotHead, yRotHead, zRotHead, xPosHead, yPosHead, zPosHead, xRotBody, yRotBody, zRotBody, xPosBody, yPosBody, zPosBody);
      }
    }

    Dictionary<string, Entity> entities = new Dictionary<string, Entity>();

    for (int i = 0; i < totalEntities; i++)
    {
      string id = entitiesArr[i].ID;
      entities[id] = entitiesArr[i];
    }

    return entities;
  }

  public static void PreprocessEntityData(Dictionary<string, Entity> entities, int totalFrames)
  {
    foreach (var entity in entities)
    {
      for (int frame = 0; frame < totalFrames; frame++)
      {
        EntityTransformation transformation = entity.Value.keyframeTransformations[frame];
        if (
          float.IsPositiveInfinity(transformation.rotationHead.x) ||
          float.IsPositiveInfinity(transformation.rotationHead.y) ||
          float.IsPositiveInfinity(transformation.rotationHead.z) ||
          float.IsPositiveInfinity(transformation.rotationBody.x) ||
          float.IsPositiveInfinity(transformation.rotationBody.y) ||
          float.IsPositiveInfinity(transformation.rotationBody.z) ||
          float.IsPositiveInfinity(transformation.positionHead.x) ||
          float.IsPositiveInfinity(transformation.positionHead.y) ||
          float.IsPositiveInfinity(transformation.positionHead.z) ||
          float.IsPositiveInfinity(transformation.positionBody.x) ||
          float.IsPositiveInfinity(transformation.positionBody.y) ||
          float.IsPositiveInfinity(transformation.positionBody.z)
        )
        {
          entity.Value.keyframeTransformations[frame] = entity.Value.keyframeTransformations[frame - 1];
        }
      }
    }
  }
}
