using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{

    bool players_turn = true;
    private List<Action> actions = new List<Action>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (actions.Count > 0) { 
        
            foreach (Action a in actions)
            {

                a.run();


            }

            for (int i = 0; i < actions.Count; i++)
                if (actions[i].IsDead())
                    actions.RemoveAt(i);


        }
        
    }

    public void setActions(List<Action> list) {

        actions.AddRange(list);
    
    }

    public void setActions(Action a)
    {

        actions.Add(a);

    }
}
