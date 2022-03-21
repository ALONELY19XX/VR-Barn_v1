using System.Collections.Generic;

public class Entity
{
  public string ID { get; set; }
  public Dictionary<int, EntityTransformation> keyframeTransformations;

  public Entity(string ID)
  {
    this.ID = ID;
    this.keyframeTransformations = new Dictionary<int, EntityTransformation>();
  }
}
