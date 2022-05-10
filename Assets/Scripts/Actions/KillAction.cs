using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAction : Action
{
    private string message;
    private Panda source_p;
    public KillAction(Panda s,Battle b):base(null,null,b)
    {
        source_p = s;
    }

    public override System.Object init()
    {
        return null;
    }

    public override System.Object _run()
    {
        source_p.kill();
        kill();
        return null;
    }
    public override System.Object cleanUp()
    {
        return null;
    }
}
