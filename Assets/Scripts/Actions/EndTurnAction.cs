using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnAction : Action
{
    private string message;
    public EndTurnAction(GameObject s, GameObject[] t):base(s,t)
    {
    }

    public override Object init()
    {
        return null;
    }

    public override Object run()
    {
        Debug.Log("Changing Turns");
        kill();
        return null;
    }
    public override Object cleanup()
    {
        return null;
    }
}
