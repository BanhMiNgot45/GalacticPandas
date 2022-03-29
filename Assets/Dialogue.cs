using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
            clear();


        if (text != null)
        {
            gameObject.transform.localScale = new Vector3(1, 0.3f, 1);

        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 0.3f, 1);
        }
    }


    public string text = null;
    void setText(string s) { text = s; }

    void clear() { text = null; }



}
