using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAction : Action
{
    private string message;
    public DebugAction(GameObject s, GameObject[] t,string _message,Battle b):base(s,t,b)
    {
        message = _message;
    }

    public override System.Object init()
    {
        return null;
    }

    public override System.Object _run()
    {
        Debug.Log(message);
        kill();
        return null;
    }
    public override System.Object cleanUp()
    {
        return null;
    }
}
