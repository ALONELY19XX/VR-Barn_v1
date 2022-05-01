using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityTransformation
{
  // Head & Body rotation properties
  public float xRotationHead { get; set; }
  public float yRotationHead { get; set; }
  public float zRotationHead { get; set; }
  public float xRotationBody { get; set; }
  public float yRotationBody { get; set; }
  public float zRotationBody { get; set; }

  // Head & Body position properties
  public float xPositionHead { get; set; }
  public float yPositionHead { get; set; }
  public float zPositionHead { get; set; }
  public float xPositionBody { get; set; }
  public float yPositionBody { get; set; }
  public float zPositionBody { get; set; }

  public Vector3 positionHead { get; set; }
  public Vector3 positionBody { get; set; }
  public Vector3 rotationHead { get; set; }
  public Vector3 rotationBody { get; set; }
  // public Quaternion rotationHead { get; set; }
  // public Quaternion rotationBody { get; set; }

  public EntityTransformation(float rxh, float ryh, float rzh, float pxh, float pyh, float pzh, float rxb, float ryb, float rzb, float pxb, float pyb, float pzb)
  {
    xRotationHead = rxh;
    yRotationHead = ryh;
    zRotationHead = rzh;
    xPositionHead = pxh;
    yPositionHead = pyh;
    zPositionHead = pzh;
  
    xRotationBody = rxb;
    yRotationBody = ryb;
    zRotationBody = rzb;
    xPositionBody = pxb;
    yPositionBody = pyb;
    zPositionBody = pzb;
  
    rotationHead = new Vector3(rxh, ryh, rzh);
    rotationBody = new Vector3(rxb, ryb, rzb); 
    positionHead = new Vector3(pxh, pyh, pzh);
    positionBody = new Vector3(pxb, pyb, pzb);
  
  }
  
  // public EntityTransformation(Quaternion rotationHead, Quaternion rotationBody, Vector3 positionHead, Vector3 positionBody)
  // {
  //   this.rotationHead = rotationHead;
  //   this.rotationBody = rotationBody;
  //   this.positionHead = positionHead;
  //   this.positionBody = positionBody;
  // }
}
