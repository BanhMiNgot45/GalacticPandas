using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    int state = 0;
	
	MainCamera camera;
    public GameObject pandaPrefab;
    public GameObject alienPrefab;

    private List<GameObject> alien_wave = new List<GameObject>();
    private GameObject[] pandas = new GameObject[3];
    private GameObject[] aliens = new GameObject[3];


    // Start is called before the first frame update
    void Start()
    {

		
		GameObject cameraObj = GameObject.Find("Main Camera");
		camera = cameraObj.GetComponent<MainCamera>();
		//cameraObj.transform.Translate(10,10,0);

    }

    // Update is called once per frame
    void Update()
    {
        switch (state){
			case 0:
				Init();
				break;
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
    void Init()
    {

        camera.transform.LookAt(GameObject.Find("CenterPivot").transform);
        //Play Music
		Debug.Log("Playing Music...");
        //GenerateAliens



        //AddPandas
        //Add Entities
        pandas[0] = Instantiate(pandaPrefab);
        pandas[1] = Instantiate(pandaPrefab);
        pandas[2] = Instantiate(pandaPrefab);
        //For Each Panda
        //Panda Move to position
        //NextWave
        //Add Aliens
        aliens[0] = Instantiate(alienPrefab);
        aliens[1] = Instantiate(alienPrefab);
        aliens[2] = Instantiate(alienPrefab);
        //For Each Alien
        //Walk to position
        //If Any Alien in ALiens is special,
        //Snap Camera
        //Animate
        //Snap Camera
        //End
        state =1;

    
    }

    void PandaSetup() { 
		Debug.Log("Setting up Pandas...");
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
			state=2;
    }

    void AlienSetup() {
		Debug.Log("Setting up Aliens...");
        //For Each Undecided Alien
            //AI Picks decision
            //After Decision, rotate to another?
        //Battle
		state=3;
    }

    void Battle() { 
		Debug.Log("Battle Phase...");
        //Sort by speed
        //Get current character
            //If character alive,
                //Use Action
                    //Add a thing for the panda to do (this is the action)
                    //Dont move to the next character, until current character SAYS their done.
                //If action is done
                    //If Check win lose
                        //Exit
						state=4;
                    //Next character
            //Else
                //Next character

        //If current character is null
            //Setup
			state=1;
    }

    void Exit()
    {
		Debug.Log("Exiting...");
        //Victory Dialouge
        //Collect Loot
        //Collect Exp
        //Pandas walk to the right
		state=5;

    }
}
