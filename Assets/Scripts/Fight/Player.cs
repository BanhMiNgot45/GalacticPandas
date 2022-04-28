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
    public GameObject canvas;


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
            panda[i].panda_name = panda[i].name = "Test Panda " + i;

            float x = Mathf.Cos(Mathf.PI * (i+1) / 4);
            float y = Mathf.Sin(Mathf.PI * (i+1) / 4);

            panda[i].transform.Translate(new Vector3(x*10,0, y*10), null);
            panda[i].SetHUD(i,this);
            panda[i].init();


            //panda[i].hud.transform.SetParent(canvas.transform, false);


        }


        battle.camera.transform.SetParent(GetActivePanda().stand.transform, true);

    }

    //
    // Update is called once per frame
    void Update()
    {


       
        if (target >= 0) { 
            GetActivePanda().UseMove(chosen_move, battle.ai.GetAlien(target));
            IncrementActivePandaIndexUntilReady();
            battle.camera.transform.SetParent(GetActivePanda().stand.transform,true);
            target = -1;
        }


        if (battle.isPlayersTurn())
        {

            IncrementActivePandaIndex(0);

            bool ready = true;
            foreach (Panda p in panda)
                if(p!=null)            
                    ready &= p.IsReady();
            if (ready)
            {

                List<Action> things = new List<Action>();
                foreach (Panda p in panda)
                {
                    if (p != null)
                    {
                        things.Add(p.GetSelectedAction());
                        p.reset();
                    }
                }
                //things.Add(new ChangeCameraAction(GameObject.Find("Main Camera"),battle.stand, battle));
                things.Add(new EndTurnAction(null, null, battle));
                SeriesAction a = new SeriesAction(null, null, things, battle);
                battle.setAction(a);
            }
            
        }
    }

    internal void SetActivePanda(int id)
    {
        GetActivePanda().isActive = false;
        active_panda = id;
        if (panda[active_panda % 3].dead)
            active_panda++;
        active_panda %= 3;

        GetActivePanda().isActive = true;
    }

    public Panda GetActivePanda()
    {
        return panda[active_panda%3];
    }

    internal void IncrementActivePandaIndex(int v)
    {

        GetActivePanda().isActive = false;
        active_panda += v;
        if (panda[active_panda%3].dead)
            active_panda++;
        active_panda %= 3;

        GetActivePanda().isActive = true;
    }

    internal void IncrementActivePandaIndexUntilReady()
    {
        int n = 0;
        while (GetActivePanda().IsReady() && n < 4){
            IncrementActivePandaIndex(1);
            n++;
        }
    }

    public Panda GetPanda(int i)
    {
        return panda[i % 3];
    }

    public int target = -1;

    public void setTarget(int i) {
        target = i;
    }


    public int chosen_move;
    public void GetPandaUseMove(int args)
    {
        chosen_move = args;
        if (target == -1)
            target = -2;
    }
}
