using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Option(int i) {
        Debug.Log(i);
        switch (i) {
            case 0:



                break;
            case 1:
                break;
            case 2:
                Application.Quit();
                break;

        }

    }
}
