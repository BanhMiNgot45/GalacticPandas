using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStatAction : Action
{

    private STAT_TYPE stat;
    private double value;
    private Panda source_p;
    private Panda target_p;

    public ChangeStatAction(Panda source_p, Panda target_p, STAT_TYPE stat, double value,Battle b):base(null,null,b)
    {
        this.value = value;
        this.stat = stat;
        this.source_p = source_p;
        this.target_p = target_p;
    }

    public override System.Object init()
    {
        return null;
    }

    Action re;

    public override System.Object _run()
    {

        if (stat == STAT_TYPE.HP)
        {
            target_p.hp = value;
            if (target_p.hp < 0)
                target_p.hp = 0;
            if(target_p.hp>target_p.maxHP)
                target_p.hp = target_p.maxHP;
            re = target_p.CheckDeath();

        }
        else if (stat == STAT_TYPE.PP)
        {
            target_p.pp = value;
            if (target_p.pp < 0)
                target_p.pp = 0;
            if (target_p.pp > target_p.maxPP)
                target_p.pp = target_p.maxPP;

        }
        else
        {


            switch (stat)
            {
                case STAT_TYPE.ATT:
                    target_p.att = value;
                    break;
                case STAT_TYPE.DEF:
                    target_p.def = value;
                    break;
                case STAT_TYPE.SPEED:
                    target_p.speed = value;
                    break;
                case STAT_TYPE.MAX_HP:
                target_p.maxHP = value;
                target_p.maxHP = (double)Mathf.Min((float)target_p.maxHP, (float)target_p.hp);
                    break;


            }
        }
    

        kill();
        return null;
    }
    public override System.Object cleanUp()
    {
        return re;
    }


}
