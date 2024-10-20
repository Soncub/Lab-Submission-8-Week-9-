using UnityEngine;

public class TargetBuilder
{
    public TargetBuilder() => targetData = new();

    private Target targetData;


    public Target Build()
    {
        Target target = targetData.Clone();
        target.transform = new GameObject("Target").transform;
        target.transform.gameObject.AddComponent<TargetGO>().target = target;
        target.Hitbox = target.transform.gameObject.AddComponent<BoxCollider>();
        target.Hitbox.size = Vector3.one * target.size;
        target.Hitbox.center = Vector3.zero + Vector3.up * target.Hitbox.size.y/2;

        GameObject model = Object.Instantiate(target.TargetModel);
        model.transform.parent = target.transform.transform;
        model.transform.localPosition = Vector3.zero;
        return target;
    }
    public Target[] BuildMass(int count)
    {
        Target[] targets = new Target[count];
        for (int i = 0; i < count; i++) targets[i] = Build();
        return targets;
    }


    public void AddSize(float value) => targetData.size = value;
    public void AddSpeed(float value) => targetData.Speed = value;
    public void AddPoints(int value) => targetData.PointValue = value;
    public void AddModel(GameObject value) => targetData.TargetModel = value;
}
