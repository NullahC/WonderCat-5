using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResverserController : MonoBehaviour
{
    private WheelJoint2D[] Wheel = null;
    private JointMotor2D left;
    private JointMotor2D right;
    // Start is called before the first frame update
    void Start()
    {
        Wheel = GetComponentsInChildren<WheelJoint2D>();
        left = Wheel[0].motor;
        right = Wheel[1].motor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag( "Reverser"))
    //    {
    //        transform.rotation = Quaternion.Euler(Vector3.up*180);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="Reverser")
        {
            left.motorSpeed = -left.motorSpeed;
            right.motorSpeed = -right.motorSpeed;
        }
        
    }
}
