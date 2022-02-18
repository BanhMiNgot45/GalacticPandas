using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public float amplitude = 1f;
    public float frequency = 2f;
    public bool x = false;
    public bool y = true;
    public bool z = false;
    public bool random = true;
    private float time = 0f;
    private float seed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (random) {
            seed = Random.Range(-2 * Mathf.PI, 2* Mathf.PI);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float newPos = amplitude * Mathf.Sin(frequency * time + seed);
        if (x) {
            transform.position += new Vector3(newPos, 0, 0); 
        }
        if (y) {
            transform.position += new Vector3(0, newPos, 0);
        }  
        if (z) {
            transform.position += new Vector3(0, 0, newPos);
        }
    }
}
