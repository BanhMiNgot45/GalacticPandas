using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Panda panda;
    public GameObject prefab;
    public Battle battle;


    // Start is called before the first frame update
    void Start()
    {
        panda = Instantiate(prefab).GetComponent<Panda>();
        panda.battle = battle;
    }

    //
    // Update is called once per frame
    void Update()
    {
        if (battle.isPlayersTurn())
        {
            if (panda.IsReady())
            {
                
                Debug.Log("Pandas are ready...");
                List<Action> things = new List<Action>();
                things.Add(panda.GetSelectedAction());
                things.Add(new EndTurnAction(null, null, battle));
                SeriesAction a = new SeriesAction(null,null,things,battle);
                panda.reset();
                battle.setAction(a);


            }
        }
    }

    public Panda GetActivePanda()
    {
        return panda;
    }

}
