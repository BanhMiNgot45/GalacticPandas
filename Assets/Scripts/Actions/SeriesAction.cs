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

    public override Object init()
    {
        return null;
    }


    private int index = 0;

    public override Object _run()
    {
        Action a = actions[index];

        if (a.IsDead())
            index++;

        a.run();

        if (index >= actions.Count)
            kill();



        return null;
    }
    public override Object cleanup()
    {
        return null;
    }
}
