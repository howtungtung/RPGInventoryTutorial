using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save(string fileName, object data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = string.Empty;
        path = Path.Combine(Application.persistentDataPath, fileName);
        Directory.CreateDirectory(Application.persistentDataPath);
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Save file at path " + path);
    }

    public static T Load<T>(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            T data = (T)formatter.Deserialize(stream);
            stream.Close();
            return data;
        }
        else
        {
            throw new Exception("File not exist at path " + path);
        }
    }
}
