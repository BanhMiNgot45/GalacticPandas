using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public int target;
    UI source;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTarget()
    {
        Debug.Log(target);
        source.chooseMoveWithTarget(target);

    }

    public void prompt(UI source) {

        this.source = source;


    
    
    }

}
