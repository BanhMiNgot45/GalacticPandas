using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STAT_TYPE
{
    HP,
    ATT,
    DEF,
    SPEED,
    MAX_HP


};

public enum EFFECT_TYPE
{

}

public enum MOVE_TYPE
{
    PHYSICAL,
    MAGICAL,
    OTHER

}





public class Move : MonoBehaviour
{

    //Animation
    public string name = "Test Move";
    public double accuracy = 100;
    public double power;
    public STAT_TYPE stat;
    public EFFECT_TYPE effect;
    public MOVE_TYPE move_type;

    public ParticleSystem ps_charge;
    public ParticleSystem ps_hit;

    public AudioSource source;

    public AudioClip[] clips;

    public AudioSource getSource() { return source; }
    public AudioClip getClip(int i) { return clips[i]; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void use(GameObject source, GameObject target) { }

    public Action GetMove(Panda source_p,Panda target_p,Battle battle)
    {

        GameObject source = source_p.gameObject;
        GameObject target = target_p?.gameObject;


        List<Action> things = new List<Action>();
       
        things.Add(new UseMoveAction(source_p, target_p,this, battle));




        return new SeriesAction(target, null, things, battle);


    }


}
