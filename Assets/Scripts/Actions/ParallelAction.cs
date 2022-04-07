﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelAction : Action
{
    private List<Action> actions;
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

    public override Object init()
    {
        return null;
    }



    public override Object _run()
    {
        bool dead = true;
        foreach(Action a in actions){
            dead &= a.IsDead();
            if(!a.IsDead())
            a.run();
        }
        if (dead)
            kill();

        return null;
    }
    public override Object cleanup()
    {
        return null;
    }
}
