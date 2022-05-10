using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDMoves : MonoBehaviour
{

    public HUDMoveButton[] buttons = new HUDMoveButton[4];

    public Player player;
    public Panda panda;

    private RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void init()
    {
        rect = gameObject.GetComponent<RectTransform>();
        //rect.offsetMin = new Vector2(10, 10);//Left Bottom
        //rect.offsetMax = new Vector2(-10, -Screen.height * (13f / 16f));//Right Top
        for (int i = 0; i < 4; i++)
        {
            buttons[i].pos = i;
            if(i==1||i==2)
                buttons[i].gui_pos = i;
            else
                buttons[i].gui_pos = Mathf.Abs(i-3);
            buttons[i].player = player;
        }
    }

    // Update is called once per frame
    void Update()
    {

        rect = gameObject.GetComponent<RectTransform>();
        rect.offsetMax = new Vector2(0,Screen.height*-.8f);//Right Top

        if (panda.isActive&&!player.battle.IsBattleRunning )
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(0, 1, 1);
        }

    }


}
