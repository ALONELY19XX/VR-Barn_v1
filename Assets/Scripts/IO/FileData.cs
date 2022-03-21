using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileData
{
    public int totalLines { get; set; }
    public string[] content { get; set; }

    private bool _split; 

    public FileData(string file, bool split = true)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, file);
        string[] content = CsvReader.ReadEntireFile(filePath);

        this.totalLines = content.Length;
        this.content = content;
    }

}
