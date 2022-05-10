using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keyboard : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Leave()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

    }


    // Update is called once per frame
    void Update()
    {
        

        }

        
}
