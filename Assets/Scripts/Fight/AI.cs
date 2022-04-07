using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Panda[] panda = new Panda[3];
    public GameObject prefab;
    public Battle battle;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            panda[i] = Instantiate(prefab).GetComponent<Panda>();
            panda[i].battle = battle;
            panda[i].transform.Translate(new Vector3(i * 10, 0,10), null);
        }
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

                foreach (Panda p in panda)
                {
                    if (p != null)
                    {
                        if (!p.IsReady())
                            p.UseMove(0);
                        things.Add(p.GetSelectedAction());
                        
                        p.reset();
                    }
                    things.Add(new ChangeCameraAction(GameObject.Find("Main Camera"), new GameObject[] { battle.stand }, battle));
                    things.Add(new EndTurnAction(null, null, battle));
                }
                SeriesAction a = new SeriesAction(null, null, things, battle);
                battle.setAction(a);
                ready = true;
            }
            
        }




    }
}
