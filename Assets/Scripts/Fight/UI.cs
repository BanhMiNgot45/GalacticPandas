using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Player player;
    public AI ai;
    public Battle battle;

    public Canvas canvas;

    public GameObject text;

    public Vector3 target;


    public GameObject parent;
    private UI parent_ui;
    public UI[] neighbors;
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

        parent_ui = (UI)parent.GetComponent(typeof(UI));
        origin = parent.transform.position;


    }

    // Update is called once per frame
    void Update()
    {

        if (!battle.ActionReady()&&battle.isPlayersTurn())
            canvas.scaleFactor = 1;
        else
            canvas.scaleFactor = 0;

        origin = parent.transform.position;
        if (parent_ui != null)
        {
            if (trigger) {
                parent_ui._delay_to_reset = parent_ui.delay_to_reset;
                foreach(UI u in neighbors) {

                    u._delay_to_reset = u.delay_to_reset;
                }
            }
            if (parent_ui.trigger || trigger)
            {
                _delay_to_reset = delay_to_reset;
            }
            else
            {
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
        if (battle == null)
        {
            Debug.Log("There is no world set! Returning...");
            return;
        }

        _delay_to_reset = 0;
        parent_ui._delay_to_reset = 0;
        foreach (UI u in neighbors)
            u._delay_to_reset = 0;

        if (section == 1)
            player.GetActivePanda().UseMove(choice);
        else if(section ==2)
            player.GetActivePanda().UseItem(choice);
        ChangePanda();

    }

    public void ChangePanda() {

        player.IncrementActivePandaIndex(1);
        LoadPandaDetails();

    }

    private void LoadPandaDetails()
    {
        Debug.Log("Changing name...");
        //Debug.Log(this.gameObject.GetComponent<Image>().);

    }

    private float setLerpTime = 60;

    private float lerpTime = 60;
    private int elapsedFrames = 0;

    void lerp(Vector3 target) {
            transform.position = Vector3.Lerp(transform.position, target, 0.1f);
    }

    public void update()
    {
        
    }

}
