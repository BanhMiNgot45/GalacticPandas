using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDMoveButton : MonoBehaviour
{
    public Player player;
    public int pos =0;
    public AudioSource select;
    // Start is called before the first frame update
    void Start()
    {
  }

    // Update is called once per frame
    void Update()
    {
        RectTransform rect;
        rect = gameObject.GetComponent<RectTransform>();
        // rect.offsetMin = new Vector2((Screen.width / 2), 0);//Left Bottom
        // rect.offsetMax = new Vector2(0, -(transform.parent.GetComponent<RectTransform>().rect.height / 2));//Right Top
        // rect.offsetMin = new Vector2((Screen.width / 2), (transform.parent.GetComponent<RectTransform>().rect.height / 2));//Left Bottom
        // rect.offsetMax = new Vector2(0, 0);//Right Top
        //
        // rect.offsetMin = new Vector2(0, 0);//Left Bottom
        // rect.offsetMax = new Vector2(-(Screen.width / 2), -(transform.parent.GetComponent<RectTransform>().rect.height / 2));//Right Top
        // rect.offsetMin = new Vector2(0, (transform.parent.GetComponent<RectTransform>().rect.height / 2));//Left Bottom
        // rect.offsetMax = new Vector2(-(Screen.width / 2), 0);//Right Top

        rect.offsetMin = new Vector2(((3-pos)/2)*(transform.parent.GetComponent<RectTransform>().rect.width / 2), (pos % 2) * (transform.parent.GetComponent<RectTransform>().rect.height / 2));//Left Bottom
        rect.offsetMax = new Vector2(-(pos / 2) * (transform.parent.GetComponent<RectTransform>().rect.width / 2), -((1+pos) % 2) * (transform.parent.GetComponent<RectTransform>().rect.height / 2));//Right Top

    }

    public void UseMove()
    {
        player.GetPandaUseMove(pos);
        select.Play();

    }
}
