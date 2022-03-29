using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public UI Profile;
    public UI Act;
    public UI Use;
    public UI Act1;
    public UI Act2;
    public UI Act3;
    public UI Act4;
    public UI Act5;

    // Start is called before the first frame update
    void Start()
    {
        Selected_Icon = Profile;
        
    }

    public UI Selected_Icon;
    public int choice_index = 0;

    // Update is called once per frame
    void Update()
    {

        //Return Tree
        if (Input.GetKeyUp(KeyCode.Return)) {

            if (Profile.trigger == false)
            {
                Profile.trigger_toggle();
                Selected_Icon = Act;
            }
            else{

                Selected_Icon.trigger_toggle();
                if (Selected_Icon == Act)
                    Selected_Icon = Act1;
                if (Selected_Icon == Use)
                    Selected_Icon = Use;

            }


        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (Profile.trigger == false)
            {
                Profile.ChangePanda();
            }
            else {

                if (Selected_Icon == Act || Selected_Icon == Use) { 
                
                    
                
                }
                if (Act.trigger)
                {

                    choice_index++;
                    choice_index %= 5;
                    Selected_Icon = Act.neighbors[choice_index];


                }
                if (Use.trigger)
                {



                }

            }

        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (Profile.trigger == false)
            {
                Profile.ChangePanda();
            }
            else
            {

                if (Selected_Icon == Act || Selected_Icon == Use)
                {



                }
                if (Act.trigger)
                {

                    choice_index--;
                    if (choice_index < 0)
                        choice_index = 4;
                    choice_index %= 5;
                    Selected_Icon = Act.neighbors[choice_index];


                }
                if (Use.trigger)
                {



                }

            }

        }

        if (Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.LeftShift)) {

            if (Profile.trigger)
            {
                if (Act.trigger)
                {

                    Act.trigger_toggle();


                }
                else if (Use.trigger)
                {



                }
                else {
                    Profile.trigger_toggle();
                }



            }


        
        
        }

    }
}
