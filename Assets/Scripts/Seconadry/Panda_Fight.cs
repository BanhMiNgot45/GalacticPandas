using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda_Fight : MonoBehaviour
{

    public bool ready = false;
    private bool my_turn = false;
    public World world;
    public UI _UI;


    private Move[] Moveset;

    public void UseItem(int i)
    {
    }

    public void UseMove(int i)
    {


    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (my_turn)
        //{
        //    if (!ready) {
        //        Action re = UI.CheckSelectedAction();
        //        if (re != null)
        //        {
        //            world.actions.add(re);
        //            ready = true;
        //        }
        //    }
        //}
    }
}
