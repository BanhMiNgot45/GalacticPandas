using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicCharacter : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 10f;
    private Rigidbody rgb;
    private ParticleSystem[] pss;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        pss = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem ps in pss) {
            ps.Stop();
        }
    }

    // Update is called once per physics frame
    void FixedUpdate()
    {
        float t = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Horizontal");
        if (t != 0 || r != 0) {
            foreach (ParticleSystem ps in pss) {
                ps.Play();
            }
        }
        else {
            foreach (ParticleSystem ps in pss) {
                ps.Stop();
            }
        }
        rgb.MovePosition(rgb.position + -transform.right * t * Time.deltaTime * speed);
        rgb.MoveRotation(rgb.rotation * Quaternion.Euler(new Vector3(0, rotationSpeed, 0) * r * Time.deltaTime));
    }
}
