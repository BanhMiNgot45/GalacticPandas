using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneAction : Action
{
    private string message;
    private int val;
    public ChangeSceneAction(int val,Battle b):base(null,null,b)
    {
        this.val = val;
    }

    public override System.Object init()
    {
        return null;
    }

    public override System.Object _run()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Inventory",UnityEngine.SceneManagement.LoadSceneMode.Single);

        return null;
    }
    public override System.Object cleanUp()
    {
        return null;
    }
}
