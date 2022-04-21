using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panda : MonoBehaviour
{

    public Battle battle;
    private Move[] Moveset;
    public Action selectedAction;
    private bool ready = false;
    public string panda_name = "Test Panda";

    public double maxHP = 10;
    public double hp = 1;
    public double maxPP = 10;
    public double pp = 10;
    public double att = 1;
    public double def = 1;
    public double PAtt = 1;
    public double PDef = 1;
    public double speed = 1;
    public static double maxSpd = 100;

    public int team = 0;

    public GameObject stand;

    public TMP_Text textMeshPro;
    public ParticleSystem textParticleSystem;
    private ParticleSystemRenderer rendererSystem;


    // Start is called before the first frame update
    void Start()
    {
        Moveset = new Move[] {

            new Move()

        };

        rendererSystem = textParticleSystem.GetComponent<ParticleSystemRenderer>();
        rendererSystem.mesh = textMeshPro.mesh;
        Debug.Log(textMeshPro.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setAction(Action a)
    {
        selectedAction = a;
        ready = true;

    }

    public bool IsReady()
    {
        return ready;
    }

    public Action GetSelectedAction()
    {
        return selectedAction;
    }

    public void UseItem(int i)
    {
    }

    public void Log(string m)
    {
        Debug.Log(m);


    }

    public void UseMove(int i,Panda target)
    {
        List<Action> things = new List<Action>();
        //things.Add(new ChangeCameraAction(GameObject.Find("Main Camera"), new GameObject[] { stand }, battle));
        //things.Add(new LerpAction(GameObject.Find("Main Camera"), null, battle, stand.transform.GetChild(0).position));
        //things.Add(new LerpRotationAction(GameObject.Find("Main Camera"), null, battle, new Vector3(stand.transform.GetChild(0).rotation.x, stand.transform.GetChild(0).rotation.y, stand.transform.GetChild(0).rotation.z)));
        // things.Add(new OpenDialogueAction(null, null, "Hello World",battle));
        // things.Add(new SeriesAction(null,null,new Action[]{
        //     new LerpAction(this.gameObject, null, battle, new Vector3(5, 2, 0)),
        //     new TimerAction(this.gameObject, null, battle, 100),
        //     new LerpAction(this.gameObject, null, battle, new Vector3(0, 0, 0)) 
        // },battle));

        things.Add(Moveset[0].GetMove(this, target,battle));
        

        setAction(new ParallelAction(null,null,things,battle));
        ready = true;


    }

    public SeriesAction CheckDeath() {

        Debug.Log(hp);
        Debug.Log("Checking");

        if (hp <= 0) {
            List<Action> things = new List<Action>();

            //Add animation death
            things.Add(new OpenDialogueAction(null, null, GetName()+" has been knocked down!", battle));

            //Kill
            kill();
        
            return new SeriesAction(null, null, things, battle);
        }

        return null;
    
    
    }

    public bool dead = false;

    public void kill() { dead = true; }

    public void reset() {
        selectedAction = null;
        ready = false;
    
    }

    internal string GetPandaName()
    {
        return panda_name;
    }

    public string GetName()
    {
        return panda_name;
    }
}
