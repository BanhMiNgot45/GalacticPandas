using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleSystemAction : Action
{
    private string message;
    private ParticleSystem pp;
    private Panda target;
    public PlayParticleSystemAction(GameObject s, Panda t,ParticleSystem pp,Battle b):base(null,null,b)
    {
        target = t;
        this.pp = pp;
    }

    public override System.Object init()
    {
        return null;
    }

    public override System.Object _run()
    {
        pp.transform.position = target.transform.position;
        pp.Play();
        kill();
        return null;
    }
    public override System.Object cleanUp()
    {
        return null;
    }
}
