using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
  /* FILES */
  public const string CAM_CONFIG_FILE = "cam_config.xcp";
  public const string MOTION_DATA_FILE = "motion_data.csv";
  public const string MOTION_DATA_DIR = "Entity Data";
  public const string CAM_CONFIG_DIR = "Camera Data";

  /* CSV VARS */
  public const int HEADER_OFFSET = 5; // ignore csv header data
  public const int ROW_OFFSET = 2; // ignore first two column meta values
  public const int ENTITY_PADDING_TOTAL = 12; // each entity owns 12 colums: 3x rotation + 3x position for head AND body
  public const int ENTITY_PADDING_POSITION = 3;
  public const int ENTITY_PADDING_ROTATION = 3;
  public const int HEADER_TITLES_OFFSET = 4;

  /* COORDINATE TRANSLATION -> VICON XYZ to UNITY XYZ */
  public const int X_INDEX_OFFSET = 2;
  public const int Y_INDEX_OFFSET = 0;
  public const int Z_INDEX_OFFSET = 1;

  /* CAMERA CONFIG VARS */
  public const string CAMERA_TAG = "Camera";
  public const string CAMERA_POSITION_TAG = "POSITION";
  public const string CAMERA_ORIENTATION_TAG = "ORIENTATION";
  public const int CAMERA_TRANSFORM_INDEX = 4;
  public const string DEVICE_ID = "DEVICEID";
  public const string USER_ID = "USERID";
  public const string SENSOR_SIZE = "SENSOR_SIZE";
  public const string FOCAL_LENGTH = "FOCAL_LENGTH";

  /* HEATMAP */
  public const int HEATMAP_ROWS = 30;
  public const int HEATMAP_COLS = 50;
}
