using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private WheelJoint2D []Wheel = null;
    // Start is called before the first frame update
    void Start()
    {
        Wheel =GetComponentsInChildren<WheelJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {

    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        Wheel[0].useMotor = true;
        Wheel[1].useMotor = true;
    }
}
