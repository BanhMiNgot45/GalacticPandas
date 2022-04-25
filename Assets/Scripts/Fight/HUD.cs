using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Image image;
    public Image health;
    public Image power;
    public TextMeshProUGUI health_text;
    public TextMeshProUGUI power_text;
    public Player player;
    public Panda panda;

    public int id;


    public bool pressed = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        health_text.text = panda.hp + "/" + panda.maxHP;
        health.color = new Color(1- (((float)panda.hp / (float)panda.maxHP)), (((float)panda.hp / (float)panda.maxHP)), 0);

        if (panda.isActive&&!player.battle.IsBattleRunning)
        {
            image.color = Color.green;
        }
        else {
            image.color = Color.grey;
        }

        if(panda.IsReady())
            image.color = Color.yellow;

        if (pressed)
        {
            Debug.Log(player);
            pressed = false;
            if (player != null)
            {
                if (player.target == -1) {

                    if (id < 3)
                    {

                        player.SetActivePanda(id);
                        player.GetActivePanda().reset(); 
                        player.battle.camera.transform.SetParent(player.GetActivePanda().stand.transform, true);

                    }
                }
                if (player.target == -2) {
                    player.setTarget(id);
                }
            
            }
        }
        // Debug.Log(player);


    }

    public void setTarget(int i)
    {
        id = i;


    }

    public void setTarget()
    {
        pressed = true;
    }
}
