using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Panda panda;
    public GameObject prefab;
    public Battle battle;


    // Start is called before the first frame update
    void Start()
    {
        panda = Instantiate(prefab).GetComponent<Panda>(); ;
    }
    //
    // Update is called once per frame
    void Update()
    {
        if (panda.IsReady())
        {
            Debug.Log("Pandas are ready...");
            List<Action> things = new List<Action>();
            things.Add(panda.GetSelectedAction());
            panda.reset();
            battle.setActions(things);


        }

    }

    public Panda GetActivePanda()
    {
        return panda;
    }

}
