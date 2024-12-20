using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public PlayerData playerData;

    public GameData(int score)
    {
        playerData = new PlayerData(score);
    }
    public void SaveData(string path, string filename)
    {
        if(!Directory.Exists(path)) Directory.CreateDirectory(path);

        FileStream file = File.Create(path+filename);
        Debug.Log("Score file saved.");
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file, this);
        file.Close();
    }

    public static GameData LoadData(string path)
    {
        if (!Directory.Exists(path)) return null;

        FileStream file = File.Open(path, FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        GameData data = (GameData)formatter.Deserialize(file);
        file.Close();
        return data;
    }
}
