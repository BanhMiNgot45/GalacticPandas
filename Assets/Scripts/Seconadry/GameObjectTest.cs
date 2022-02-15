using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectTest : MonoBehaviour
{

	public GameObject myPrefab;
	
	private List<GameObject> entities = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
	entities.Add(Instantiate(myPrefab));
        
    }

    // Update is called once per frame
    void Update()
    {
	entities[0].transform.Rotate(0f, 0.0f, 1.0f,Space.Self);        
    }
}
