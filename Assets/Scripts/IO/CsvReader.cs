using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class CsvReader
{
    public static string[] ReadEntireFile(string path)
    {
        return File.ReadAllLines(path);
    }
}
