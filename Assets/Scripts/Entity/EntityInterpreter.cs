using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public static class EntityInterpreter
{
  public static int GetTotalEntities(string[] fileContent)
  {
    if (fileContent.Length > Constants.HEADER_OFFSET)
    {
      string[] values = fileContent[Constants.HEADER_OFFSET].Split(',');
      return (values.Length - Constants.ROW_OFFSET) / Constants.ENTITY_PADDING_TOTAL;
    }
    return 0;
  }

  public static Entity[] InitEntities(string[] frameData, int totalEntities)
  {

    Entity[] entities = new Entity[totalEntities];

    for (int i = 0; i < totalEntities; i++)
    {
      entities[i] = new Entity($"Entity-{i}");
    }

    for (int frame = Constants.HEADER_OFFSET; frame < frameData.Length; frame++)
    {
      string[] valuesRaw = frameData[frame].Split(',');

      for (int i = 0; i < totalEntities; i++)
      {
        string rxsh = valuesRaw[2 + i * Constants.ENTITY_PADDING_TOTAL + 2];
        float rxh = string.IsNullOrEmpty(rxsh) ? float.PositiveInfinity : float.Parse(rxsh, CultureInfo.InvariantCulture) * Mathf.Rad2Deg;
        string rysh = valuesRaw[2 + i * Constants.ENTITY_PADDING_TOTAL + 0];
        float ryh = string.IsNullOrEmpty(rysh) ? float.PositiveInfinity : float.Parse(rysh, CultureInfo.InvariantCulture) * Mathf.Rad2Deg;
        string rzsh = valuesRaw[2 + i * Constants.ENTITY_PADDING_TOTAL + 1];
        float rzh = string.IsNullOrEmpty(rzsh) ? float.PositiveInfinity : float.Parse(rzsh, CultureInfo.InvariantCulture) * Mathf.Rad2Deg;

        string pxsh = valuesRaw[2 + i * Constants.ENTITY_PADDING_TOTAL + 3];
        float pxh = string.IsNullOrEmpty(pxsh) ? float.PositiveInfinity : float.Parse(pxsh, CultureInfo.InvariantCulture) / 1000.0f;
        string pyhs = valuesRaw[2 + i * Constants.ENTITY_PADDING_TOTAL + 5];
        float pyh = string.IsNullOrEmpty(pyhs) ? float.PositiveInfinity : float.Parse(pyhs, CultureInfo.InvariantCulture) / 1000.0f;
        string pzsh = valuesRaw[2 + i * Constants.ENTITY_PADDING_TOTAL + 4];
        float pzh = string.IsNullOrEmpty(pzsh) ? float.PositiveInfinity : float.Parse(pzsh, CultureInfo.InvariantCulture) / 1000.0f;

        string rxsb = valuesRaw[2 + i * Constants.ENTITY_PADDING_TOTAL + 8];
        float rxb = string.IsNullOrEmpty(rxsb) ? float.PositiveInfinity : float.Parse(rxsb, CultureInfo.InvariantCulture) * Mathf.Rad2Deg;
        string rysb = valuesRaw[2 + i * Constants.ENTITY_PADDING_TOTAL + 6];
        float ryb = string.IsNullOrEmpty(rysb) ? float.PositiveInfinity : float.Parse(rysb, CultureInfo.InvariantCulture) * Mathf.Rad2Deg;
        string rzsb = valuesRaw[2 + i * Constants.ENTITY_PADDING_TOTAL + 7];
        float rzb = string.IsNullOrEmpty(rzsb) ? float.PositiveInfinity : float.Parse(rzsb, CultureInfo.InvariantCulture) * Mathf.Rad2Deg;

        string pxsb = valuesRaw[2 + i * Constants.ENTITY_PADDING_TOTAL + 9];
        float pxb = string.IsNullOrEmpty(pxsb) ? float.PositiveInfinity : float.Parse(pxsb, CultureInfo.InvariantCulture) / 1000.0f;
        string pysb = valuesRaw[2 + i * Constants.ENTITY_PADDING_TOTAL + 11];
        float pyb = string.IsNullOrEmpty(pysb) ? float.PositiveInfinity : float.Parse(pysb, CultureInfo.InvariantCulture) / 1000.0f;
        string pzsb = valuesRaw[2 + i * Constants.ENTITY_PADDING_TOTAL + 10];
        float pzb = string.IsNullOrEmpty(pzsb) ? float.PositiveInfinity : float.Parse(pzsb, CultureInfo.InvariantCulture) / 1000.0f;

        entities[i].keyframeTransformations[frame - 5] = new EntityTransformation(rxh, ryh, rzh, pxh, pyh, pzh, rxb, ryb, rzb, pxb, pyb, pzb);
      }
    }

    return entities;
  }
}
