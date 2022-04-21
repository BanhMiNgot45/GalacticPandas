using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelAction : Action
{
    private List<Action> actions;
    private List<Action> followup_actions;
    public ParallelAction(GameObject s, GameObject[] t, List<Action> a, Battle b) : base(s, t, b)
    {
        actions = a;
    }

    public ParallelAction(GameObject s, GameObject[] t, Action[] aa, Battle b) : base(s, t, b)
    {
        actions = new List<Action>();
        foreach (Action a in aa)

            actions.Add(a);
    }

    public override System.Object init()
    {
        followup_actions = new List<Action>();
        return null;
    }



    public override System.Object _run()
    {
        bool dead = true;
        foreach(Action a in actions){
            dead &= a.IsDead();
            if (!a.IsDead())
            {
                a.run();
            }
        }

        if (dead)
        {
            //if (followup_actions.Count == 0)
                kill();
            //else
            //{
            //    actions = followup_actions;
            //    dead = false;
            //}
        }

        return null;
    }
    public override System.Object cleanUp()
    {
        return null;//new ParallelAction(null, null, followup_actions, battle);
    }
}
