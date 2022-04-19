using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStatAction : Action
{

    private STAT_TYPE stat;
    private double value;
    private Panda source_p;
    private Panda target_p;

    public ChangeStatAction(Panda source_p, Panda target_p, STAT_TYPE stat, double value,Battle b):base(null,null,b)
    {
        this.value = value;
        this.stat = stat;
        this.source_p = source_p;
        this.target_p = target_p;
    }

    public override System.Object init()
    {
        return null;
    }

    public override System.Object _run()
    {
        kill();
        return null;
    }
    public override System.Object cleanUp()
    {
        return null;
    }
}
