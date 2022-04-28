using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorInv : MonoBehaviour
{
    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform rect;
        rect = inventory.GetComponent<RectTransform>();
        rect.offsetMin = new Vector2((float)Screen.width / 3f, (float)Screen.height / (1/1.7f));//Left Bottom
        rect.offsetMax = new Vector2(0,0);//Right Top

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
