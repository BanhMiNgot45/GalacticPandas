using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpRotationAction : Action
{
    private Vector3 location;
    public LerpRotationAction(GameObject s, GameObject[] t, Battle b,Vector3 l) : base(s, t, b)
    {
        location = l;
    }

    public override Object init()
    {
        return null;
    }

    public override Object _run()
    {

        if (source.transform.rotation==location) {
            kill();
        }else
            lerp();


        return null;
    }
    public override Object cleanup()
    {
        return null;
    }

    void lerp()
    {
        source.transform.position = Vector3.Lerp(source.transform.position, location, 0.1f);
    }
}
