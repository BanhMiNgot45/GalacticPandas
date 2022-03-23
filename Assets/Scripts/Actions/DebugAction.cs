using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAction : Action
{
    private string message;
    public DebugAction(GameObject s, GameObject[] t,string _message):base(s,t)
    {
        message = _message;
    }

    public override Object init()
    {
        return null;
    }

    public override Object run()
    {
        Debug.Log(message);
        kill();
        return null;
    }
    public override Object cleanup()
    {
        return null;
    }
}
