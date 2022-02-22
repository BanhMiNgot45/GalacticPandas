using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda_Fight : MonoBehaviour
{

    public bool ready = false;
    private bool my_turn = false;

    public UI_Fight UI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (my_turn)
        {
            if (!ready) {
                Object re = UI.CheckSelectedAction();
                if (re != null) {
                    ready = true;
                    //Add ACTION
                }
            }
        }
    }
}
