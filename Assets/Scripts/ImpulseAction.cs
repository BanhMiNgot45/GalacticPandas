using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ImpulseAction : Action
{
private GameObject source;
private GameObject[] targets;

public ImpulseAction(GameObject s, GameObject[] t) : base(s, t)
{
}



public override Object run()
{
    if (trigger())
    {
        effect();
        cleanup();
    }

    return null;
}

public abstract bool trigger();
public abstract Object effect();
    




}
