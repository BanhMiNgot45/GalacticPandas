using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda : MonoBehaviour
{

    public Battle battle;
    private Move[] Moveset;
    public Action selectedAction;
    private bool ready = false;
    public string panda_name = "NULL";

    public GameObject stand;

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
        List<Action> things = new List<Action>();
        things.Add(new ChangeCameraAction(GameObject.Find("Main Camera"), new GameObject[] { stand }, battle));
        things.Add(new LerpAction(GameObject.Find("Main Camera"), null, battle, stand.transform.GetChild(0).position));
        //things.Add(new OpenDialogueAction(null, null, "Hello World",battle));
        things.Add(new LerpAction(this.gameObject, null, battle, new Vector3(5, 2, 0)));
        things.Add(new TimerAction(this.gameObject, null, battle, 100));
        things.Add(new LerpAction(this.gameObject, null, battle, new Vector3(0, 0, 0)));
        

        setAction(new SeriesAction(null,null,things,battle));
        ready = true;


    }

    public void reset() {
        selectedAction = null;
        ready = false;
    
    }

    internal string GetPandaName()
    {
        return panda_name;
    }
}
