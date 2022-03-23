using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    public Player player;
    public AI ai;
    public World world;


    public Vector3 target;

    GameObject parent;
    private UI parent_ui;
    public bool trigger = false;
    public int delay_to_reset = 10;
    private int _delay_to_reset = 0;

    public int section= 0;
    public int choice = 0;

    public int gui_depth = 0;

    Vector3 origin;


    void OnGUI()
    {


        GUI.depth = gui_depth;

    }

    // Start is called before the first frame update
    void Start()
    {


        parent = this.transform.parent.gameObject;
        parent_ui = (UI)parent.GetComponent(typeof(UI));
        origin = parent.transform.position;

        if (parent_ui != null) {
            //world = parent_ui.world;
//ai = parent_ui.ai;
            //player = parent_ui.player;
        }

    }

    // Update is called once per frame
    void Update()
    {
        origin = parent.transform.position;
        if (parent_ui != null)
        {
            if (parent_ui.trigger)
            {
                _delay_to_reset = delay_to_reset;
            }
            else
            {
                trigger = false;
                if (_delay_to_reset > 0)
                    _delay_to_reset--;
            }

            if (_delay_to_reset > 0)
                lerp(origin + target);
            else
                lerp(origin);
        }
    }


    public void trigger_on(){
        trigger = true;
    }
    public void trigger_off() { 
        trigger = false; 
    }
    public void trigger_toggle() { 
        trigger = !trigger; 
    }

    public void choose()
    {
        Debug.Log("Choosing");
        if (world == null)
        {
            Debug.Log("There is no world set! Returning...");
            return;
        }
    
        if(section == 1)
            player.GetActivePanda().UseMove(choice);
        else if(section ==2)
            player.GetActivePanda().UseItem(choice);

    }



    private float setLerpTime = 60;

    private float lerpTime = 60;
    private int elapsedFrames = 0;

    void lerp(Vector3 target) {
            transform.position = Vector3.Lerp(transform.position, target, 0.1f);
    }


}
