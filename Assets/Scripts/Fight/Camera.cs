using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject stand;


    // Start is called before the first frame update
    void Start()
    {
        //this.transform.SetParent(stand.transform,false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition != Vector3.zero) {

            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition,Vector3.zero, 0.1f);
            // = new Vector3(0, 0, 0);
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
        
        }
    }

    void ChangePivot(Transform stand) {

        this.transform.SetParent(stand);
        
    }
}
