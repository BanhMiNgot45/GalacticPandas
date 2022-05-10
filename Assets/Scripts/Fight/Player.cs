using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public Panda[] panda = new Panda[3];
    public int active_panda = 0;

    public GameObject prefabs;
    public Battle battle;
    public UI ui;
    public Canvas canvas;

    public Move[] random_moves;
    public int num;


    // Start is called before the first frame update
    void Start()
    {
        LoadPandas();
    }

    string[] names = { "Grizz", "Yogi", "Panda" };


    public void LoadPandas()
    {

        for (int i = 0; i < 3; i++)
        {

            panda[i] = Instantiate(prefabs).GetComponent<Panda>();
            panda[i].battle = battle;
            panda[i].panda_name = panda[i].name = names[i];
            
            //for(int n=0;n<4;n++)
            //    panda[i].Moveset[n] = random_moves[Random.Range(0, num-1)]; 
                


        

            float x = Mathf.Cos(Mathf.PI * (i+1) / 4);
            float y = Mathf.Sin(Mathf.PI * (i+1) / 4);

            panda[i].transform.Translate(new Vector3(x*15,0, y*15), null);
            panda[i].SetHUD(i,this,canvas);
            panda[i].init();


            //panda[i].hud.transform.SetParent(canvas.transform, false);


        }


        battle.camera.transform.SetParent(GetActivePanda().stand.transform, true);

    }

    //
    // Update is called once per frame
    void Update()
    {

        bool isLoss = true;
        foreach (Panda p in panda)
        {
            if (p != null)
                isLoss &= p.dead;
        }
        if (isLoss)
        {
            battle.Loss();
            return;
        }
        if (target >= 0)
        {
            if (GetActivePanda())
            {
                Panda t;
                if (target / 3 > 0) 
                    t = battle.ai.GetAlien(target);
                else
                    t = GetPanda(target);

                GetActivePanda().UseMove(chosen_move, t);
                IncrementActivePandaIndexUntilReady();
                battle.camera.transform.SetParent(GetActivePanda().stand.transform, true);
                target = -1;
            }
        
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
        if(GetActivePanda())
            GetActivePanda().isActive = false;
        active_panda += v;
        
        if(panda[active_panda%3])
        if (panda[active_panda%3].dead)
            active_panda++;
        active_panda %= 3;

        if (GetActivePanda())
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

    public void Zoom() {

        foreach (Panda p in panda) {
            p.Zoom();
        }


    }
}
