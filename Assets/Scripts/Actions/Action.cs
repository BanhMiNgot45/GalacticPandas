using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
    protected GameObject source;
    protected GameObject[] targets;
    protected Battle battle;
    private bool dead = false;

    protected Action(GameObject s, GameObject[] t,Battle b)
    {
        source = s;
        targets = t;
        battle = b;
    }

    public bool IsDead()
    {
        return dead;
    }

    
    private bool hasInit = false;

    public abstract Object init();
    public abstract Object _run();
    public abstract Object cleanup();

    public  Object run()
    {

        if (!hasInit)
        {
            hasInit = true;
            init();
        }

        if (!IsDead())
            return _run();
        return null;
    
    }

    public void kill()
    {
        dead = true;
    }


}