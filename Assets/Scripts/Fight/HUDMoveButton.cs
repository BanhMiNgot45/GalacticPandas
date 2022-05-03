using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDMoveButton : MonoBehaviour
{
    public Player player;
    public int pos =0;
    public int gui_pos = 0;
    public AudioSource select;
    public Text _text;
    public Image image;
    bool disable = false;
    // Start is called before the first frame update
    void Start()
    {
  }

    // Update is called once per frame
    void Update()
    {
        image = GetComponent<Image>();
        disable = false;
        image.color = Color.white;
        Debug.Log(player);
        var text = player
            .GetActivePanda()
            .GetMove(pos)
            .name;
        if (text == "Null") { 
            text = "";
            disable = true;
            image.color = Color.gray;
        }
        _text.text = text;
        //RectTransform rect;
        //rect = gameObject.GetComponent<RectTransform>();
        // rect.offsetMin = new Vector2((Screen.width / 2), 0);//Left Bottom
        // rect.offsetMax = new Vector2(0, -(transform.parent.GetComponent<RectTransform>().rect.height / 2));//Right Top
        // rect.offsetMin = new Vector2((Screen.width / 2), (transform.parent.GetComponent<RectTransform>().rect.height / 2));//Left Bottom
        // rect.offsetMax = new Vector2(0, 0);//Right Top
        //
        // rect.offsetMin = new Vector2(0, 0);//Left Bottom
        // rect.offsetMax = new Vector2(-(Screen.width / 2), -(transform.parent.GetComponent<RectTransform>().rect.height / 2));//Right Top
        // rect.offsetMin = new Vector2(0, (transform.parent.GetComponent<RectTransform>().rect.height / 2));//Left Bottom
        // rect.offsetMax = new Vector2(-(Screen.width / 2), 0);//Right Top

        //rect.offsetMin = new Vector2(((3-gui_pos)/2)*(transform.parent.GetComponent<RectTransform>().rect.width / 2), (gui_pos % 2) * (transform.parent.GetComponent<RectTransform>().rect.height / 2));//Left Bottom
        //rect.offsetMax = new Vector2(-(gui_pos / 2) * (transform.parent.GetComponent<RectTransform>().rect.width / 2), -((1+ gui_pos) % 2) * (transform.parent.GetComponent<RectTransform>().rect.height / 2));//Right Top

    }

    public void UseMove()
    {
        if (!disable) { 
        Debug.Log(pos);
        Debug.Log(gui_pos);
        player.GetPandaUseMove(pos);
        select.Play();
    }
    }
}
