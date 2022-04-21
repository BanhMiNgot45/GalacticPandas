using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ImpulseAction : Action
{
private GameObject source;
private GameObject[] targets;

public ImpulseAction(GameObject s, GameObject[] t,Battle b) : base(s, t, b)
{
}



public override System.Object _run()
{
    if (trigger())
    {
        effect();
        cleanUp();
    }

    return null;
}

public abstract bool trigger();
public abstract System.Object effect();
    




}
