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
        things_charge.Add(new OpenDialogueAction(null, null, source_p.GetName() + " used " + move.name + " on " + target_p.panda_name + ".", battle));

        //things.Add(new PlaySoundAction(move.getSource(), battle));


        if (target_p==null||target_p.dead) {

            Debug.Log("FAIL");
            things_after.Add(new OpenDialogueAction(null, null, "But it failed...", battle));
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

            things_after.Add(new PlaySoundAction(move.getSource(), move.getClip(1), battle));
            things_after.Add(new TimerAction(null,null,battle,100));
            //If we are changing the hp stat of a non-team member, then it's an attack
            if (move.stat == STAT_TYPE.HP && target_p.team != source_p.team)
                {
                    things_after.Add(new ChangeCameraAction(battle.camera, target_p.stand, battle));
                    if (target_p.def >= move.power + source_p.att)
                    {
                        things_after.Add(new ChangeStatAction(source_p, target_p, move.stat, target_p.hp - 1, battle));
                    }
                    else
                    {
                        things_after.Add(new ChangeStatAction(source_p, target_p, move.stat,
                            target_p.hp - (move.power + source_p.att - target_p.def), battle));
                    }

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
