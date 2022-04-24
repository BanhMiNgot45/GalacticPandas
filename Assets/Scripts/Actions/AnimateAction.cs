using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateAction : Action
{
    private float time;
    private Animator animator;
    private string name;
    public AnimateAction(Animator s,string name,Battle b,float time):base(null,null,b)
    {
        this.time = time;
        this.name = name;
        animator = s;
    
    }

    public override System.Object init()
    {
        animator.Play(name);
        return null;
    }

    private float _time = 0;

    public override System.Object _run()
    {
        _time += 1;

        animator.Play(name);
        if (_time >= time) {   
             kill();
        }

        return null;
    }
    public override System.Object cleanUp()
    {
        return null;
    }
}
