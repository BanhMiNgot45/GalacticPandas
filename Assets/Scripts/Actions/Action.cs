using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
    protected GameObject source;
    protected GameObject[] targets;
    protected Battle battle;
    private bool dead = false;

    public void setTargets(GameObject[] t)
    {
        targets = t;
    }

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

    public abstract System.Object init();
    public abstract System.Object _run();

    public abstract System.Object cleanUp();

    public System.Object run()
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