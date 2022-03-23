using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda : MonoBehaviour
{
    private Move[] Moveset;
    public Action selectedAction;
    private bool ready = false;

    // Start is called before the first frame update
    void Start()
    {
        Moveset = new Move[] {

            new Move()

        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setAction(Action a)
    {
        selectedAction = a;
        ready = true;

    }

    public bool IsReady()
    {
        return ready;
    }

    public Action GetSelectedAction()
    {
        return selectedAction;
    }

    public void UseItem(int i)
    {
    }

    public void UseMove(int i)
    {
        setAction(new DebugAction(this.gameObject,null,"Using move " + i));
        ready = true;


    }

    public void reset() {
        selectedAction = null;
        ready = false;
    
    }

}
