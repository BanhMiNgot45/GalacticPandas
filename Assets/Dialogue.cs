using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text _text;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        if (text != "null")
        {
        

        //rect.offsetMin = new Vector2(10, 10); //Left Bottom

        //rect.offsetMax = new Vector2(-10, -Screen.height * (3f / 4f)); //Right Top
    }
}

    // Update is called once per frame
    void Update()
    {
        if (player != null && player.target == -1&& !player.battle.IsBattleRunning)
            text = "What will "+player.GetActivePanda().panda_name+" do?";

        if (player!=null && player.target == -2)
            text = "Choose a target to use "+player.GetActivePanda().GetMove(player.chosen_move).name+" on.";

        if (Input.GetKeyUp(KeyCode.Return))
            clear();


        if (Input.GetKeyUp(KeyCode.Backspace) && player.target == -2)
        {
            player.target = -1;
        }

        if (text!="null")
        if (text !="")
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1);
            setTMPText(text);


        }
        else
        {
            gameObject.transform.localScale = new Vector3(0, 1f, 1);
            //setTMPText("");
        }
    }


    public string text = null;
    void setText(string s) { text = s; }

    void clear() {
        if(text!="null")
            text = ""; }

    public void setTMPText(string s)
    {
        _text.text = s;
    }


}
