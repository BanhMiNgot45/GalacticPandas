using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScript : MonoBehaviour
{

    int state = 0;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state){
            case 1:
                PandaSetup();
                break;
            case 2:
                AlienSetup();
                break;
            case 3:
                Battle();
                break;
            case 4:
                Exit();
                break;
        }


    }
    void Init() { 
        
        //Play Music
        //GenerateAliens
        //AddPandas
            //Add Entities
            //For Each Panda
                   //Panda Move to position
        //NextWave
            //Add Aliens
            //For Each Alien
                    //Walk to position
            //If Any Alien in ALiens is special,
                //Snap Camera
                //Animate
                //Snap Camera
            //End

    
    }

    void PandaSetup() { 
        //Get current Panda
        //If Panda is ready
            //Next Panda
            //Return
        
        //Using current Panda
            //Activate UI
            //If UI is Ready
                //Next Panda

        //If all Pandas are ready
            //Alien Setup
    }

    void AlienSetup() {
        //For Each Undecided Alien
            //AI Picks decision
            //After Decision, rotate to another?
        //Battle
    }

    void Battle() { 
        //Sort by speed
        //Get current character
            //If character alive,
                //Use Action
                    //Add a thing for the panda to do (this is the action)
                    //Dont move to the next character, until current character SAYS their done.
                //If action is done
                    //If Check win lose
                        //Exit
                    //Next character
            //Else
                //Next character

        //If current character is null
            //Setup
    }

    void Exit()
    {
        //Victory Dialouge
        //Collect Loot
        //Collect Exp
        //Pandas walk to the right

    }


}
