using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTarget : TargetBuilder
{
    public SecondTarget()
    {
        //carnivalTarget = new Target("Second Target");
    }
    public override void AddSize()
    {
        carnivalTarget["size"] = "";
    }
    public override void AddSpeed()
    {
        carnivalTarget["speed"] = "";
    }
    public override void AddPoints()
    {
        carnivalTarget["points"] = "";
    }
}
