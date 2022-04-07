using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAction : Action
{
    private Vector3 location;

    public LerpAction(GameObject s, GameObject[] t, Battle b, Vector3 l) : base(s, t, b)
    {
        location = new Vector3(l.x, l.y, l.z);
    }

    public override Object init()
    {
        return null;
    }

    public override Object _run()
    {

        Debug.Log(location);
        Debug.Log(source.transform.position);
        if (source.transform.position == location)
        {
            kill();
        }
        else
            lerp();

        if (Vector3.Distance(source.transform.position, location) <= 0.5f)
        {
            source.transform.position = location;
            kill();
        }


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
