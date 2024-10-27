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
    public void SaveData(string path)
    {


        FileStream file = File.Create(path+".byte");
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file, this);
        file.Close();
    }

    public static GameData LoadData(string path)
    {


        FileStream file = File.Open(path+".byte", FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        GameData data = (GameData)formatter.Deserialize(file);
        file.Close();
        return data;
    }
}
