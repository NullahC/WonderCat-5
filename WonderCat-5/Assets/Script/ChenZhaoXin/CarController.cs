using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private WheelJoint2D []Wheel = null;
    private Rigidbody2D FreezeZ = null;
    // Start is called before the first frame update
    void Start()
    {
        Wheel =GetComponentsInChildren<WheelJoint2D>();
        FreezeZ = GetComponent<Rigidbody2D>();
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
        FreezeZ.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        FreezeZ.constraints = RigidbodyConstraints2D.None;
    }
}
