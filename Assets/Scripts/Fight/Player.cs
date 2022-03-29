using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Panda[] panda = new Panda[3];
    public int active_panda = 0;
    public GameObject prefab;
    public Battle battle;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++ ) { 
        panda[i] = Instantiate(prefab).GetComponent<Panda>();
        panda[i].battle = battle;
            panda[i].transform.Translate(new Vector3(i * 10, 0, 0),null);
    } }

    //
    // Update is called once per frame
    void Update()
    {
        if (battle.isPlayersTurn())
        {
            bool ready = true;
            foreach (Panda p in panda)
                ready &= p.IsReady();
            if (ready)
            {

                Debug.Log("Pandas are ready...");
                List<Action> things = new List<Action>();
                foreach (Panda p in panda)
                {
                    things.Add(p.GetSelectedAction());
                    things.Add(new EndTurnAction(null, null, battle));
                    p.reset();
                }
                SeriesAction a = new SeriesAction(null, null, things, battle);
                battle.setAction(a);

            }
        }
    }

    public Panda GetActivePanda()
    {
        return panda[active_panda];
    }

    internal void IncrementActivePandaIndex(int v)
    { 
        active_panda += v;
        active_panda %= 3;
    }
}
