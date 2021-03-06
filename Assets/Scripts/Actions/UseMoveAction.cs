using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMoveAction : Action
{
    private Move move;
    private Panda source_p;
    private Panda target_p;
    private Action re;
    public UseMoveAction(Panda source_p, Panda target_p,Move move,Battle b):base(null,null,b)
    {
        this.move = move;
        this.source_p = source_p;
        this.target_p = target_p;
    }

    public override System.Object init()
    {

        return null;
    }

    public override System.Object _run()
    {
        List<Action> things_charge = new List<Action>();
        List<Action> things_after = new List<Action>();

        bool good = true;

        things_charge.Add(new PlaySoundAction(move.getSource(),move.getClip(0), battle));
        if(move.ps_charge!=null)
        things_charge.Add(new PlayParticleSystemAction(null, source_p, move.ps_charge, battle));
        things_charge.Add(new OpenDialogueAction(null, null,
            source_p.GetName() + " used " + move.name + " on " + target_p.panda_name + ".", battle));
        // if (move.ps_charge != null)
        //     things_after.Add(new StopParticleSystemAction(null, null, move.ps_charge, battle));


         if (target_p==null||target_p.dead) {

            Debug.Log("FAIL");
            things_after.Add(new OpenDialogueAction(null, null, "But it failed...", battle));
            good = false;
        }

        if (source_p.pp-move.Mana_Cost<0)
        {

            Debug.Log("FAIL");
            things_after.Add(new OpenDialogueAction(null, null, "But they don't have enough energy.", battle));
            good = false;
        }
        if (move.accuracy > 0)
            {
                double hit = Random.Range(0, 100);
                if (hit > move.accuracy)
                {
                    things_after.Add(new OpenDialogueAction(null, null, source_p.GetName() + " missed!",battle));
                good &= false;
                }
        }

            if (good && target_p.team != source_p.team)
            {
                double dodge = Random.Range(0, 100);
                if (dodge <= target_p.speed-1)
                {
                    things_after.Add(new OpenDialogueAction(null, null, target_p.GetName() + " dodged!", battle));
                good &= false;
                }
            }

            if (good)
        {

            source_p.pp -= move.Mana_Cost;

            if (move.ps_hit != null)
                things_after.Add(new PlayParticleSystemAction(null, target_p, move.ps_hit, battle));
            things_after.Add(new PlaySoundAction(move.getSource(), move.getClip(1), battle));
            things_after.Add(new TimerAction(null,null,battle,100));
            //If we are changing the hp stat of a non-team member, then it's an attack
            if (move.stat == STAT_TYPE.HP)
                if (target_p.team != source_p.team)
                {
                    things_after.Add(new ChangeCameraAction(battle.camera, target_p.stand, battle));
                    Debug.Log((move.power + source_p.att - target_p.def));
                    things_after.Add(new ChangeStatAction(source_p, target_p, move.stat, target_p.hp - Mathf.Max(1, (float)(move.power + source_p.att - target_p.def)), battle));



                }
                else {
                    things_after.Add(new ChangeStatAction(source_p, target_p, move.stat, target_p.hp + Mathf.Max(1, (float)(move.power + source_p.PAtt)), battle));

                }

            if (move.stat == STAT_TYPE.PP)
                if (target_p.team != source_p.team)
                {
                    things_after.Add(new ChangeCameraAction(battle.camera, target_p.stand, battle));
                    Debug.Log((move.power + source_p.att - target_p.def));
                    things_after.Add(new ChangeStatAction(source_p, target_p, move.stat, target_p.hp - Mathf.Max(1, (float)(move.power + source_p.att - target_p.def)), battle));



                }
                else
                {
                    things_after.Add(new ChangeStatAction(source_p, target_p, move.stat, target_p.hp + Mathf.Max(1, (float)(move.power + source_p.PAtt)), battle));

                }

        }



        List<Action> things = new List<Action>();
        things.Add(new ParallelAction(null, null, things_charge, battle));
        things.Add(new ParallelAction(null, null, things_after, battle));
        re = new SeriesAction(null, null, things, battle);

        kill();
        return null;
    }
    public override System.Object cleanUp()
    {
        return re;
    }
}
