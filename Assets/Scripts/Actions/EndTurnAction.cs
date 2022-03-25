using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnAction : Action
{
    private string message;
    public EndTurnAction(GameObject s, GameObject[] t,Battle b):base(s,t,b)
    {
    }

    public override Object init()
    {
        return null;
    }

    public override Object _run()
    {
        battle.changeTurns();
        kill();
        return null;
    }
    public override Object cleanup()
    {
        return null;
    }
}
