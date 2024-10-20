using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTarget : TargetBuilder
{
    public SecondTarget()
    {

        BoxCollider boxCollider = new BoxCollider()
        {
            size = new Vector3(2, 2, 2),
        };

        carnivalTarget = new Target(GameManager.Instance.targetModels[1], boxCollider);
    }
    public override void AddSize()
    {
        // carnivalTarget. = "";
    }
    public override void AddSpeed()
    {
        carnivalTarget.Speed = 2;
    }
    public override void AddPoints()
    {
        carnivalTarget.PointValue = 5;
    }
}