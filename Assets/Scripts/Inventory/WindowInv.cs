using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowInv : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rect;
        rect = this.GetComponent<RectTransform>();
        rect.offsetMin = new Vector2((float)Screen.width / 3f, (float)Screen.height * (5f / 10f));//Left Bottom
        rect.offsetMax = new Vector2(-100, -15);//Right Top

    }
}
