using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Panda[] aliens = new Panda[3];
    public GameObject prefab;
    public Battle battle;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        LoadAliens();
    }


    public void LoadAliens()
    {
        for (int i = 0; i < 3; i++)
        {
            aliens[i] = Instantiate(prefab).GetComponent<Panda>();
            aliens[i].battle = battle;
            aliens[i].team = 1;
            aliens[i].panda_name = "Alien " + i;
            float x = Mathf.Cos(Mathf.PI * (i + 5) / 4);
            float y = Mathf.Sin(Mathf.PI * (i + 5) / 4);

            aliens[i].transform.Translate(new Vector3(x * 15, 0, y * 15), null);
            aliens[i].SetHUD(i+3,battle.player,canvas);
            aliens[i].init();
            //aliens[i].hud.transform.SetParent(canvas.transform, false);
        }
    }

    public Panda GetAlien(int i)
    {
        return aliens[i % 3];}

    private bool ready = false;

    // Update is called once per frame
    void Update()
    {

        bool isVictory = true;
        foreach (Panda p in aliens) {
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
                List<Action> things = new List<Action>();
                foreach (Panda p in aliens)
                {
                    if (p != null && !p.dead)
                    {
                        if (!p.IsReady())
                        {
                            int i = Random.Range(0, 3);
                            Debug.Log(p.GetMove(i).name);
                            
                                i = Random.Range(0, 3);
                                Debug.Log(i);
                            

                        p.UseMove(i, battle.player.GetPanda(Random.Range(0, 3)));
                        }
                    

                    things.Add(p.GetSelectedAction());
                        p.reset();
                    }
                    
                }
                //things.Add(new ChangeCameraAction(GameObject.Find("Main Camera"), battle.stand, battle));
                things.Add(new EndTurnAction(null, null, battle));
                SeriesAction a = new SeriesAction(null, null, things, battle);
                battle.setAction(a);
                ready = true;
            }
            
        }
    }

    public void Zoom()
    {

        foreach (Panda p in aliens)
        {
            p.Zoom();
        }


    }
}
