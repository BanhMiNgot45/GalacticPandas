using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text _text;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        rect.offsetMin = new Vector2(10, 10);//Left Bottom
        rect.offsetMax = new Vector2(-10, -Screen.height * (3f / 4f));//Right Top

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
            clear();

        if(text!="null")
        if (text !="")
        {
            gameObject.transform.localScale = new Vector3(0.9f, 0.3f, 1);
            setTMPText(text);


        }
        else
        {
            gameObject.transform.localScale = new Vector3(0, 0.3f, 1);
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
