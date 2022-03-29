using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDialogueAction: Action
{
    private string message;
    public OpenDialogueAction(GameObject s, GameObject[] t,string _message,Battle b):base(s,t,b)
    {
        message = _message;
        battle.dialogue.text = message;
    }

    public override Object init()
    {
        return null;
    }

    public override Object _run()
    {
        Debug.Log(message);
        if(battle.dialogue.text == null)
            kill();
        

        return null;
    }
    public override Object cleanup()
    {
        return null;
    }
}
