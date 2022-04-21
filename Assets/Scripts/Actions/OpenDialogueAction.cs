using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDialogueAction: Action
{
    private string message;
    public OpenDialogueAction(GameObject s, GameObject[] t,string _message,Battle b):base(s,t,b)
    {
        message = _message;
    }

    public override System.Object init()
    {
        battle.dialogue.text = message;
        return null;
    }

    public override System.Object _run()
    {
        //Debug.Log(message);
        if (battle.dialogue.text == "")
        {
            Debug.Log("Dead");
            kill();
        }
        else
        {
            battle.dialogue.setTMPText(message);
        }
        

        return null;
    }
    public override System.Object cleanUp()
    {
        return null;
    }
}
