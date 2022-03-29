using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{

    public bool players_turn = true;
    private Action action =null;
    public UI ui;
    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool ActionReady() { return action != null; }
    // Update is called once per frame
    void Update()
    {
        if (action !=null) {


            action.run();

            if (action.IsDead())
                action = null;

        


        }
        
    }

    public bool isPlayersTurn() { return players_turn; }

    public void changeTurns() {

        Debug.Log("Changing Turns");
        players_turn = !players_turn;

    
    }

    public void setAction(Action a) {

        action = a;
    
    }

}
