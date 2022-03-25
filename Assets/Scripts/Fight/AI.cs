using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Battle battle;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private bool ready = false;

    // Update is called once per frame
    void Update()
    {
        if (!battle.isPlayersTurn())
        {
            if (!battle.ActionReady())
            {
                Debug.Log("AI is ready...");
                List<Action> things = new List<Action>();
                things.Add(new TimerAction(this.gameObject, null, battle, 100));
                things.Add(new EndTurnAction(null, null, battle));
                SeriesAction a = new SeriesAction(null, null, things, battle);
                battle.setAction(a);
                ready = true;
            }
        }




    }
}
