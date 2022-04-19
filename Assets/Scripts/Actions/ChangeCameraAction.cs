using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraAction : Action
{
    MainCamera camera;
    public ChangeCameraAction(GameObject s, GameObject[] t,Battle b):base(s,t,b)
    {
        
    }

    public override System.Object init()
    {
        return null;
    }

    public override System.Object _run()
    {


        source.transform.SetParent(targets[0].transform,false);
        kill();
        return null;
    }
    public override System.Object cleanUp()
    {
        return null;
    }
}
