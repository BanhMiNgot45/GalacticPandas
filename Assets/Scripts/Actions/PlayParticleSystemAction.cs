using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleSystemAction : Action
{
    private string message;
    private ParticleSystem pp;
    public PlayParticleSystemAction(GameObject s, GameObject[] t,ParticleSystem pp,Battle b):base(s,t,b)
    {
        this.pp = pp;
    }

    public override System.Object init()
    {
        return null;
    }

    public override System.Object _run()
    {
        pp.Play();
        kill();
        return null;
    }
    public override System.Object cleanUp()
    {
        return null;
    }
}
