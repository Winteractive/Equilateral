﻿using UnityEngine;
using System.Collections;

public class AddForce : MonoBehaviour
{
    public float force;
    public float extraGrav;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<JelloPressureBody>().AddForce(Vector2.up * force);

        }
    }
}
