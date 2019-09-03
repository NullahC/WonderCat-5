using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResverserController : MonoBehaviour
{
    public WheelJoint2D LWheel;
    public WheelJoint2D RWheel;
    private JointMotor2D left;
    private JointMotor2D right;
    // Start is called before the first frame update
    void Start()
    {
        left = LWheel.motor;
        right = RWheel.motor;
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
        if (collision.gameObject.CompareTag("Reverser"))
        {
            left.motorSpeed = -400;
            right.motorSpeed = -400;
            LWheel.motor = left;
            RWheel.motor = right;
            GameObject.FindGameObjectWithTag("Hero").transform.rotation = Quaternion.Euler(Vector3.left*180);
        }
        
    }
}
