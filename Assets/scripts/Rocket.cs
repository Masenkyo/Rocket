using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Vector3 velocity;
    Vector3 acceleration;
    GameObject Earth;
    GameObject Moon;
    void Start()
    {
        Earth = GameObject.Find("Earth");
        Moon = GameObject.Find("Moon");
        velocity = new Vector3(1, 1, 0);
    }

    
    void Update()
    {
        Vector3 r_a = Earth.transform.position - transform.position;
        Vector3 accelerationEarth = 10 / (r_a.magnitude * r_a.magnitude) * r_a.normalized;

        Vector3 r_m = Moon.transform.position - transform.position;
        Vector3 accelerationMoon = 5 / (r_m.magnitude * r_m.magnitude) * r_m.normalized;

        acceleration = accelerationEarth + accelerationMoon;

        transform.LookAt(transform.position + velocity);
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}
