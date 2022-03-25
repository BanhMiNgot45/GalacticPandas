using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAction : Action
{
    private string message;
    private int time = 0;//In frames;
    public TimerAction(GameObject s, GameObject[] t, Battle b,int ti) : base(s, t, b)
    {
        message = "Timer Done!";
        time = ti;
    }

    public override Object init()
    {
        return null;
    }

    public override Object _run()
    {
        time--;
        if (time == 0)
        { 
            Debug.Log(message);
            kill();
        }

        return null;
    }
    public override Object cleanup()
    {
        return null;
    }
}
