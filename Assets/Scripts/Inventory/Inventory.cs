using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{

    public GameObject inventory;
    public GameObject shop;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform rect;
        rect = inventory.GetComponent<RectTransform>();
        rect.offsetMin = new Vector2(0,0);//Left Bottom
        rect.offsetMax = new Vector2(0,-(float)Screen.height/1.7f);//Right Top

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
