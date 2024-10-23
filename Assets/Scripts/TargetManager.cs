using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TargetManager : MonoBehaviour, ISaveable
{
    [SerializeField] List<GameObject> targetModels;

    [SerializeField] Transform[] startAndEndPoints; 

    TargetLine targetSet1;
    TargetLine targetSet2;
    TargetLine targetSet3;

    [SerializeField] Vector2 countAndSpeed1;
    [SerializeField] Vector2 countAndSpeed2;
    [SerializeField] Vector2 countAndSpeed3;

    public string SaveID => throw new System.NotImplementedException();

    private void Awake()
    {
        TargetBuilder builder1 = new();
        TargetBuilder builder2 = new();
        TargetBuilder builder3 = new();

        builder1.AddPoints(10);
        builder2.AddPoints(15);
        builder3.AddPoints(30);

        builder1.AddSize(1.5f);
        builder2.AddSize(1);
        builder3.AddSize(0.5f);

        builder1.AddSpeed(countAndSpeed1.y);
        builder2.AddSpeed(countAndSpeed2.y);
        builder3.AddSpeed(countAndSpeed3.y);

        builder1.AddModel(targetModels[0]);
        builder2.AddModel(targetModels[1]);
        builder3.AddModel(targetModels[2]);

        targetSet1 = new (builder1.BuildMass((int)countAndSpeed1.x), startAndEndPoints[0], startAndEndPoints[1]);
        targetSet2 = new (builder2.BuildMass((int)countAndSpeed2.x), startAndEndPoints[2], startAndEndPoints[3]);
        targetSet3 = new (builder3.BuildMass((int)countAndSpeed3.x), startAndEndPoints[4], startAndEndPoints[5]);

    }
    private void FixedUpdate()
    {
        targetSet1.FixedUpdate(Time.fixedDeltaTime);
        targetSet2.FixedUpdate(Time.fixedDeltaTime);
        targetSet3.FixedUpdate(Time.fixedDeltaTime);
    }




    public void Load(SavedJsonData loading)
    {
        targetSet1.time = loading.time1;
        targetSet2.time = loading.time2;
        targetSet3.time = loading.time3;

        for (int i = 0; i < targetSet1.targets.Length; i++) targetSet1.targets[i].transform.gameObject.SetActive(loading.active1[i]);
        for (int i = 0; i < targetSet2.targets.Length; i++) targetSet2.targets[i].transform.gameObject.SetActive(loading.active2[i]);
        for (int i = 0; i < targetSet3.targets.Length; i++) targetSet3.targets[i].transform.gameObject.SetActive(loading.active3[i]);

    }

    public SavedJsonData Save()
    {
        SavedJsonData result = new();
        result.time1 = targetSet1.time;
        result.time2 = targetSet2.time;
        result.time3 = targetSet3.time;

        result.active1 = new bool[targetSet1.count];
        result.active2 = new bool[targetSet2.count];
        result.active3 = new bool[targetSet3.count];

        for (int i = 0; i < result.active1.Length; i++) result.active1[i] = targetSet1.targets[i].transform.gameObject.activeSelf;
        for (int i = 0; i < result.active2.Length; i++) result.active2[i] = targetSet2.targets[i].transform.gameObject.activeSelf;
        for (int i = 0; i < result.active3.Length; i++) result.active3[i] = targetSet3.targets[i].transform.gameObject.activeSelf;

        return result;
    }



}

[System.Serializable]
public class TargetLine
{
    public Target[] targets;
    public int count;
    Transform start;
    Transform end;

    public float time;
    readonly float travelTime;

    public TargetLine(Target[] targets, Transform start, Transform end)
    {
        this.targets = targets;
        count = targets.Length;
        this.start = start;
        this.end = end;

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].transform.parent = start;
            targets[i].transform.localPosition = Vector3.zero;
        }
        travelTime = Vector3.Distance(start.position, end.position) / targets[0].Speed / count;
    }

    public void FixedUpdate(float deltaTime)
    {
        time += deltaTime / count;

        for (int i = 0; i < targets.Length; i++)
        {
            float position = (time + (travelTime / count * i)) % travelTime;
            targets[i].transform.position = Vector3.Lerp(start.position, end.position, position);
            if(position < 0.001f || position > 0.999f) targets[i].transform.gameObject.SetActive(true);
        }
    }
}


public interface ISaveable
{
    string SaveID { get; }
    public abstract SavedJsonData Save();
    public abstract void Load(SavedJsonData loading);
}

[System.Serializable]
public class SavedJsonData
{
    public float time1;
    public bool[] active1;
    public float time2;
    public bool[] active2;
    public float time3;
    public bool[] active3;
}