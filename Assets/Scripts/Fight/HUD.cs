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

    public int id;


    public bool pressed = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed)
        {
            Debug.Log(player);
            pressed = false;
            if (player != null)
            {
            
                Debug.Log(id);
                player.setTarget(id);
            
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
