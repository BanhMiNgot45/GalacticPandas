using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Panda[] panda = new Panda[3];
    public int active_panda = 0;
    public GameObject prefab;
    public Battle battle;
    public UI ui;


    // Start is called before the first frame update
    void Start()
    {
        LoadPandas();
    }


    public void LoadPandas()
    {

        for (int i = 0; i < 3; i++)
        {
            panda[i] = Instantiate(prefab).GetComponent<Panda>();
            panda[i].battle = battle;
            panda[i].panda_name = "Test Panda " + i;
            panda[i].transform.Translate(new Vector3(i * 10, 0, 0), null);
            panda[i].SetHUD(i,this);
            
        }

    }

    //
    // Update is called once per frame
    void Update()
    {
        if (battle.isPlayersTurn())
        {
            bool ready = true;
            foreach (Panda p in panda)
                if(p!=null)            
                    ready &= p.IsReady()||p.dead;
            if (ready)
            {

                Debug.Log("Pandas are ready...");
                List<Action> things = new List<Action>();
                foreach (Panda p in panda)
                {
                    if (p != null)
                    {

                        things.Add(p.GetSelectedAction());
                        
                        p.reset();
                    }
                }
                things.Add(new ChangeCameraAction(GameObject.Find("Main Camera"), new GameObject[] { battle.stand }, battle));
                things.Add(new EndTurnAction(null, null, battle));
                SeriesAction a = new SeriesAction(null, null, things, battle);
                battle.setAction(a);
            }
            
        }
    }

    public Panda GetActivePanda()
    {
        return panda[active_panda%3];
    }

    internal void IncrementActivePandaIndex(int v)
    { 
        active_panda += v;
        if (panda[active_panda%3].dead)
            active_panda++;
        active_panda %= 3;
    }

    public Panda GetPanda(int i)
    {
        return panda[i % 3];
    }

    public int target = -1;

    public void setTarget(int i) {

        target = i;
    }

    public void GetPandaUseMove(int args)
    {
        if (target == -1)
            return;
        Debug.Log(target);
        GetActivePanda().UseMove(args,battle.ai.GetAlien(target));
        IncrementActivePandaIndex(1);


    }
}
