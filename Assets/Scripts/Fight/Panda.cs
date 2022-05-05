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
    public double hp = 10;
    public double maxPP = 10;
    public double pp = 10;
    public double att = 1;
    public double def = 1;
    public double PAtt = 1;
    public double PDef = 1;
    public double speed = 1;
    public static double maxSpd = 100;
    public GameObject model;

    public GameObject Move1;
    public GameObject Move2;
    public GameObject Move3;
    public GameObject Move4;

    public Image icon;



    private Animator animator;

    public int team = 0;

    public GameObject stand;
    public HUD hud;
    public HUDMoves hudMoves;

    public bool isActive = false;


    public TMP_Text textMeshPro;

  

    public ParticleSystem ps;
    private ParticleSystemRenderer rendererSystem;


    // Start is called before the first frame update
    void Start()
    {

   

    }

    public void init() {

        model.transform.LookAt(new Vector3(0, 0, 0));
        model.transform.Rotate(new Vector3(0, 90, 0));
        hudMoves.player = battle?.player;
        hudMoves.init();

        animator = model.GetComponent<Animator>();

        Move1 = Instantiate(Move1);
        Move1.transform.SetParent(this.transform, false);
        Move2 = Instantiate(Move2);
        Move2.transform.SetParent(this.transform, false);
        Move3 = Instantiate(Move3);
        Move3.transform.SetParent(this.transform, false);
        Move4 = Instantiate(Move4);
        Move4.transform.SetParent(this.transform, false);

        Moveset = new Move[] {

            Move1.GetComponent<Move>(),
            Move2.GetComponent<Move>(),
            Move3.GetComponent<Move>(),
            Move4.GetComponent<Move>()

    };

        //rendererSystem = textParticleSystem.GetComponent<ParticleSystemRenderer>();
        //rendererSystem.mesh = textMeshPro.mesh;
        //Debug.Log(textMeshPro.text);
    }

    public void SetHUD(int pos,Player player,Canvas canvas) {
        hud.player = player;
        hud.setTarget(pos,canvas);

        hudMoves.transform.SetParent(canvas.transform, false);
        hud.panda = this;


    }


    float time = 0;

    // Update is called once per frame
    void Update()
    {

       
        time += 0.01f;
        if (!dead)
        {
            time = 0;
            gameObject.transform.localScale = new Vector3(1f, 1f, 1);

        }
        else
        {
            time += 0.01f;
            animator.Play("Base Layer.Die",0,time);
            //gameObject.transform.localScale = new Vector3(0, 0f, 1);
            ready = true;
        }



    }

    public Move GetMove(int i) {
        return Moveset[i];
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
        things.Add(new ChangeCameraAction(battle.camera,this.stand,battle));


        List<Action> things2 = new List<Action>();

        things2.Add(new AnimateAction(animator,"Base Layer.Stand",battle,1));
        things2.Add(Moveset[i].GetMove(this, target,battle));
        things2.Add(new AnimateAction(animator, "Base Layer.GetDown", battle, 1));
        things.Add(new SeriesAction(null, null, things2, battle));


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
            if (team == 1)
                things.Add(new KillAction(this, battle));
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

    public void Zoom() {


        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));

    }
}
