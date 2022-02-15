using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPiece : MonoBehaviour
{

    float i;
    float rate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        i = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        i+=Mathf.Abs(rate);
        if (i>=5) { i = -5;rate *= -1; }
        transform.Rotate(0,0,rate);

    }
}
