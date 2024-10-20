using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] List<GameObject> targetModels;

    [SerializeField] Transform[] startAndEndPoints; 

    TargetLine targetSet1;
    TargetLine targetSet2;
    TargetLine targetSet3;

    [SerializeField] Vector2 countAndSpeed1;
    [SerializeField] Vector2 countAndSpeed2;
    [SerializeField] Vector2 countAndSpeed3;


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
}

[System.Serializable]
public class TargetLine
{
    public Target[] targets;
    public int count;
    Transform start;
    Transform end;

    float time;
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
        time += deltaTime;

        for (int i = 0; i < targets.Length; i++)
        {
            float position = (time + (travelTime / count * i)) % travelTime;
            targets[i].transform.position = Vector3.Lerp(start.position, end.position, position);
            if(position < 0.001f || position > 0.999f) targets[i].transform.gameObject.SetActive(true);
        }
    }
}