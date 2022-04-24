using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStand : MonoBehaviour
{

    public CameraPivot pivot;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(pivot.transform);
    }
}


