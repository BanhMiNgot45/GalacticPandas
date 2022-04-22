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
        LoadAliens();
    }


    public void LoadAliens()
    {
        for (int i = 0; i < 1; i++)
        {
            panda[i] = Instantiate(prefab).GetComponent<Panda>();
            panda[i].battle = battle;
            panda[i].team = 1;
            panda[i].panda_name = "Test Alien";
            panda[i].transform.Translate(new Vector3(i * 10, 0, 10), null);
        }
    }

    public Panda GetAlien(int i)
    {
        return panda[i % 3];}

    private bool ready = false;

    // Update is called once per frame
    void Update()
    {

        bool isVictory = true;
        foreach (Panda p in panda) {
            if(p!=null)
                isVictory &= p.dead;
        }
        if (isVictory) {
            battle.Victory();
            return;
        }
        if (!battle.isPlayersTurn())
        {
            if (!battle.ActionReady())
            {
                Debug.Log("AI is ready...");
                List<Action> things = new List<Action>();

                foreach (Panda p in panda)
                {
                    if (p != null && !p.dead)
                    {
                        if (!p.IsReady())
                            p.UseMove(0,battle.player.GetPanda(0));
                        things.Add(p.GetSelectedAction());
                        
                        p.reset();
                    }
                }

                things.Add(new ChangeCameraAction(GameObject.Find("Main Camera"), new GameObject[] { battle.stand }, battle));
                things.Add(new EndTurnAction(null, null, battle));
                SeriesAction a = new SeriesAction(null, null, things, battle);
                battle.setAction(a);
                ready = true;
            }
            
        }




    }
}
