using UnityEngine;
using System.Linq;
using System.IO;

public static class Files
{
  public static string[] GetAllDataFiles()
  {
    string[] files = Directory.GetFiles(Path.Combine(Application.streamingAssetsPath, Constants.MOTION_DATA_DIR), "*.csv");
    return files.Select(file => Path.GetFileName(file)).ToArray();
  }
}
