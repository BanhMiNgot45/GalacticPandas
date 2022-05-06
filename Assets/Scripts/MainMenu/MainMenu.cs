using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public string[] levelnames;
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
        Debug.Log(i);
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
