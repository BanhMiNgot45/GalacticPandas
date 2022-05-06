using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{


    public string[] levelnames;
    public Battle battle;
    public TMP_Text _text;

    private int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (battle.state > 0)
        {
            time++;

            this.transform.localScale = new Vector3(1, 1, 1);
            if (battle.state == 1)
            {
            

            _text.text = "Victory!";
            if (time > 600)
                SceneManager.LoadScene(levelnames[Random.Range(0, levelnames.Length - 1)], LoadSceneMode.Single);
            }
            else
            {
             _text.text = "Game Over :(";
             if (time > 600)
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
    }
        else
        {
            this.transform.localScale = new Vector3(0, 1, 1);

        }
        
    }
}
