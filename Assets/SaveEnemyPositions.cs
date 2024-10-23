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

    string DataPath() => Application.persistentDataPath + "/Saves";

    public void Save()
    {
        if (!Directory.Exists(DataPath())) Directory.CreateDirectory(DataPath());

        SavedJsonData data = savables[0].Save();
        if (data == null) return;

        using StreamWriter save = File.CreateText(DataPath() + "/" + "TargetPositions.json");
        save.WriteLine(JsonUtility.ToJson(data, true));
    }

    public void Load()
    {
        if (!Directory.Exists(DataPath())) Directory.CreateDirectory(DataPath());
        if (!File.Exists(DataPath() + "/TargetPositions.json")) Save();

        SavedJsonData data = new();
        using StreamReader load = File.OpenText(DataPath() + "/" + "TargetPositions.json");
        JsonUtility.FromJsonOverwrite(load.ReadToEnd(), data);
        savables[0].Load(data);
    }
}
