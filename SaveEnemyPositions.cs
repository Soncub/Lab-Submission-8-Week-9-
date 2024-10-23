using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.IO;

public class SaveEnemyPositions : MonoBehaviour
{
    private ISaveable[] savables;

    private void Awake()
    {
        savables = FindObjectsOfType<MonoBehaviour>().OfType<ISaveable>().ToArray();
    }

    string DataPath() => Application.persistentDataPath + "Saves";

    public void Save()
    {
        if (Directory.Exists(DataPath())) Directory.CreateDirectory(DataPath());
        using StreamWriter save = File.CreateText(DataPath() + "/" + "TargetPositions.json");
        save.WriteLine(JsonUtility.ToJson(this, true));
    }

    public void Load()
    {
        if (Directory.Exists(DataPath())) Directory.CreateDirectory(DataPath());
        if (!File.Exists(DataPath() + "TargetPositions")) Save();
        using StreamReader load = File.OpenText(DataPath() + "/" + "TargetPositions.json");
        JsonUtility.FromJsonOverwrite(load.ReadToEnd(), this);
    }
}
