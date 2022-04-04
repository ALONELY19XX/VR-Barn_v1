using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System.Linq;
using System.Globalization;
using System;

public static class Cameras
{
  public static Dictionary<string, GameObject> Init(GameObject cameraModel)
  {
    Dictionary<string, GameObject> cameras = new Dictionary<string, GameObject>();

    string cameraCalibration = Path.Combine(Application.streamingAssetsPath, Constants.CAM_CONFIG_DIR, Constants.CAM_CONFIG_FILE);

    XmlDocument document = new XmlDocument();
    document.Load(cameraCalibration);

    XmlNodeList cameraNodes = document.GetElementsByTagName(Constants.CAMERA_TAG);

    foreach (XmlNode camera in cameraNodes)
    {
      string deviceId = camera.Attributes[Constants.DEVICE_ID].Value;
      string sensorSizeRaw = camera.Attributes[Constants.SENSOR_SIZE].Value;
      int[] sensorSize = Array.ConvertAll(sensorSizeRaw.Split(' '), s => int.Parse(s));
      //Debug.Log($"{sensorSize[0]} {sensorSize[1]}");

      XmlNode cameraTransform = camera.ChildNodes[Constants.CAMERA_TRANSFORM_INDEX].FirstChild;
      string positionRaw = cameraTransform.Attributes[Constants.CAMERA_POSITION_TAG].Value;
      string orientationRaw = cameraTransform.Attributes[Constants.CAMERA_ORIENTATION_TAG].Value;
      string focalLengthRaw = cameraTransform.Attributes[Constants.FOCAL_LENGTH].Value;

      //Debug.Log($"{sensorSizeRaw} ----- {focalLengthRaw}");

      float[] position = positionRaw.Split(' ').Select(coordinate => float.Parse(coordinate, CultureInfo.InvariantCulture) / 1000.0f).ToArray();
      float[] rotation = orientationRaw.Split(' ').Select(rotation => float.Parse(rotation, CultureInfo.InvariantCulture) / 1000.0f).ToArray();
      float focalLength = float.Parse(focalLengthRaw, CultureInfo.InvariantCulture);


      Vector3 positionVector = new Vector3(position[0], position[2], position[1]);
      Quaternion rotationQuaternion = new Quaternion(rotation[0], rotation[2], rotation[1], rotation[3]);

      var cameraInstance = GameObject.Instantiate(cameraModel, positionVector, rotationQuaternion);
      cameraInstance.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
      cameraInstance.transform.Rotate(-90.0f, 0.0f, 0.0f);
      cameraInstance.name = deviceId;

      var cameraComponent = cameraInstance.transform.Find("Camera").GetComponent<Camera>();
      cameraComponent.usePhysicalProperties = true;
      cameraComponent.focalLength = focalLength;
      cameraComponent.sensorSize = new Vector2(sensorSize[0], sensorSize[1]);

      var cameraGroup = GameObject.Find("Camera Group");
      cameraInstance.transform.SetParent(cameraGroup.transform, true);

      cameras[deviceId] = cameraInstance;
    }

    return cameras;
  }
}

// public class CameraLoader : MonoBehaviour
// {
//   [SerializeField]
//   private GameObject cameraPrefab;

//   private string camerConfigPath = Path.Combine(Application.streamingAssetsPath, Constants.CAM_CONFIG_FILE);

//   void Start()
//   {
//     XmlDocument configFile = new XmlDocument();
//     configFile.Load(camerConfigPath);

//     XmlNodeList cameras = configFile.GetElementsByTagName(Constants.CAMERA_TAG);

//     foreach (XmlNode camera in cameras)
//     {
//       string deviceId = camera.Attributes[Constants.DEVICE_ID].Value;

//       XmlNode cameraTransform = camera.ChildNodes[Constants.CAMERA_TRANSFORM_INDEX].FirstChild;
//       string positionRaw = cameraTransform.Attributes[Constants.CAMERA_POSITION_TAG].Value;
//       string orientationRaw = cameraTransform.Attributes[Constants.CAMERA_ORIENTATION_TAG].Value;

//       float[] position = positionRaw.Split(' ').Select(coordinate => ParseFloat(coordinate)).ToArray();
//       float[] rotation = orientationRaw.Split(' ').Select(rotation => ParseFloat(rotation)).ToArray();

//       Vector3 positionVector = new Vector3(position[0], position[2], position[1]);
//       Quaternion rotationQuaternion = new Quaternion(rotation[0], rotation[2], rotation[1], rotation[3]);

//       var cameraInstance = Instantiate(cameraPrefab, positionVector, rotationQuaternion);
//       cameraInstance.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
//       cameraInstance.transform.Rotate(-90.0f, 0.0f, 0.0f);
//       cameraInstance.name = deviceId;

//       var cameraGroup = GameObject.Find("Camera Group");
//       cameraInstance.transform.SetParent(cameraGroup.transform, true);
//     }
//   }
