using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    private bool doingVictory = false;
    public bool players_turn = true;
    private Action action =null;
    public UI ui;
    public Dialogue dialogue;
    public GameObject stand;
    public Player player;
    public AI ai;

    public GameObject camera;

    public bool IsBattleRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool ActionReady() { return action != null; }
    // Update is called once per frame
    void Update()
    {


        IsBattleRunning = (action!=null);
        if (IsBattleRunning) {
            action.run();
            if (action.IsDead())
                action = null;
        }
        
    }

    public bool isPlayersTurn() { return players_turn; }

    public void changeTurns() {
        players_turn = !players_turn;
    }

    public void setAction(Action a) {
        action = a;
    }

    internal void Victory()
    {
        if (doingVictory)
            return;
        List<Action> things = new List<Action>();

        doingVictory = true;
        things.Add(new OpenDialogueAction(null, null, "Victory!", this));
        things.Add(new ChangeSceneAction(0, this));

        action = new SeriesAction(null, null, things, this);

    }
}
