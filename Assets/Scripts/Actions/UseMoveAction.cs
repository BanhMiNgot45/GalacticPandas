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
        List<Action> things = new List<Action>();

        bool good = true;

            if (move.accuracy > 0)
            {
                double hit = Random.Range(0, 100);
                if (hit > move.accuracy)
                {
                    Debug.Log("MISS");
                    things.Add(new OpenDialogueAction(null, null, source_p.GetName() + " missed!",battle));
                good &= false;
                }
        }

            if (good && target_p.team != source_p.team)
            {
                double dodge = Random.Range(0, 100);
                if (dodge <= target_p.speed-1)
                {
                    Debug.Log("DODGE");
                    things.Add(new OpenDialogueAction(null, null, target_p.GetName() + " dodged!", battle));
                good &= false;
                }
            }

            if (good)
            {
                //If we are changing the hp stat ofa none-team member, then it's an attack
                if (move.stat == STAT_TYPE.HP && target_p.team != source_p.team)
                {
                    if (target_p.def >= move.power + source_p.att)
                    {
                        things.Add(new ChangeStatAction(source_p, target_p, move.stat, target_p.hp - 1, battle));
                        Debug.Log("Hit " +target_p.GetName() + " for 1 damage.");
                    }
                    else
                    {
                        things.Add(new ChangeStatAction(source_p, target_p, move.stat,
                            target_p.hp - (move.power + source_p.att - target_p.def), battle));
                        Debug.Log("Hit "+ target_p.GetName() + " for "+ (move.power + source_p.att - target_p.def) + " damage.");
                }

                }


            }

            re = new ParallelAction(null, null, things, battle);

        kill();
        return null;
    }
    public override System.Object cleanUp()
    {
        return re;
    }
}
