using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdTarget : TargetBuilder
{
    public ThirdTarget()
    {

        BoxCollider boxCollider = new BoxCollider()
        {
            size = new Vector3(2, 2, 2),
        };

        carnivalTarget = new Target(GameManager.Instance.targetModels[2], boxCollider);
    }
    public override void AddSize()
    {
        // carnivalTarget. = "";
    }
    public override void AddSpeed()
    {
        carnivalTarget.Speed = 1;
    }
    public override void AddPoints()
    {
        carnivalTarget.PointValue = 10;
    }
}
