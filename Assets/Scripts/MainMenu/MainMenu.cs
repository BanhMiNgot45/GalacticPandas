using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public string[] levelnames = {"Fight_Wood","Fight_Snow","Fight_Desert","Fight_Mountain","Fight_Volcano","Fight_Space"};
    public AudioSource button_click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Option(int i) {
        string[] levelnames = { "Fight_Plains","Fight_Snow","Fight_Desert","Fight_Mountain","Fight_Volcano","Fight_Space"};

        Debug.Log(i);
        Debug.Log(levelnames.Length);
        button_click.Play();
        switch (i) {
            case 0:
                SceneManager.LoadScene(levelnames[Random.Range(0, levelnames.Length-1)], LoadSceneMode.Single);

                break;
            case 1:
                break;
            case 2:
                Application.Quit();
                break;

        }

    }
}
