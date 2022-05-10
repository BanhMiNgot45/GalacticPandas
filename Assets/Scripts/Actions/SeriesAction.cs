using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeriesAction : Action
{
    private List<Action> actions;
    public SeriesAction(GameObject s, GameObject[] t, List<Action> a, Battle b) : base(s, t, b)
    {
        actions = a;
    }

    public SeriesAction(GameObject s, GameObject[] t,Action[] aa, Battle b) : base(s, t, b)
    {
        actions = new List<Action>();
        foreach (Action a in aa)
        
            actions.Add(a);
    }

    public override System.Object init()
    {
        return null;
    }


    private int index = 0;

    public override System.Object _run()
    {
        Action a = actions[index];
        if (a == null)
        {
            index++;
        }
        else
        {
            if (a.IsDead())
            {
                System.Object re = a.cleanUp();
                if (re is Action)
                {
                    actions[index] = (Action)re;

                }
                else
                {
                    index++;
                }
            }


            a.run();
        }
        if (index >= actions.Count)
            kill();



        return null;
    }
    public override System.Object cleanUp()
    {
        return null;
    }
}
