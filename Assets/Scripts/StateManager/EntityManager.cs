using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EntityManager
{
  public static Entity[] entities;

  public static void Init(int totalEntities)
  {
    entities = new Entity[totalEntities];
  }
}
