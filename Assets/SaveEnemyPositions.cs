using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.IO;

public class SaveEnemyPositions : MonoBehaviour
{
    private ISaveable<SavedJsonData> positionSaver;

    private void Awake()
    {
        positionSaver = FindObjectsOfType<MonoBehaviour>().OfType<ISaveable<SavedJsonData>>().First();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) SavePositions();

        if (Input.GetKeyDown(KeyCode.L)) LoadPositions();

    }

    string DataPath() => Application.persistentDataPath + "/Saves";

    public void SavePositions()
    {
        if (!Directory.Exists(DataPath())) Directory.CreateDirectory(DataPath());

        SavedJsonData data = positionSaver.Save();
        if (data == null) return;

        using StreamWriter save = File.CreateText(DataPath() + "/" + "TargetPositions.json");
        save.WriteLine(JsonUtility.ToJson(data, true));
    }

    public void LoadPositions()
    {
        if (!Directory.Exists(DataPath())) Directory.CreateDirectory(DataPath());
        if (!File.Exists(DataPath() + "/TargetPositions.json")) SavePositions();

        SavedJsonData data = new();
        using StreamReader load = File.OpenText(DataPath() + "/" + "TargetPositions.json");
        JsonUtility.FromJsonOverwrite(load.ReadToEnd(), data);
        positionSaver.Load(data);
    }
}
