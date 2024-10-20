using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetBuilder
{
    protected Target carnivalTarget;
    public Target CarnivalTarget
    {
        get { return carnivalTarget; }
    }
    public abstract void AddSize();
    public abstract void AddSpeed();
    public abstract void AddPoints();
}
