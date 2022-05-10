using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
	public bool rotate = true;
    public float speed = 1.0f;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(rotate)
        transform.Rotate(0,speed,0,Space.Self);
    }
}


