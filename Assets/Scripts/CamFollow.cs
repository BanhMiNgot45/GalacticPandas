using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null) {
            Debug.LogError("Target GameObject not set!");
        }
        else {
            offset = transform.position - target.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + offset;
    }
}
