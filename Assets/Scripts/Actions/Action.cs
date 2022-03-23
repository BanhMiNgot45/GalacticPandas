using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
    protected GameObject source;
    protected GameObject[] targets;
    private bool dead = false;

    protected Action(GameObject s, GameObject[] t)
    {
        source = s;
        targets = t;
    }

    public bool IsDead()
    {
        return dead;
    }

    public abstract Object init();
    public abstract Object run();
    public abstract Object cleanup();

    public void kill()
    {
        dead = true;
    }


}