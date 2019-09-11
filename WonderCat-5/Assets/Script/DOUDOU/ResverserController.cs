using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResverserController : MonoBehaviour
{
    public float ResversedSpeed = 400;
    private WheelJoint2D[] Wheel = null;
    private JointMotor2D left;
    private JointMotor2D right;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            Wheel = GetComponentsInChildren<WheelJoint2D>();
            left = Wheel[1].motor;
            right = Wheel[0].motor;
        }
        catch(System.Exception)
        {

        }
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
            left.motorSpeed = -ResversedSpeed;
            right.motorSpeed = -ResversedSpeed;
            Wheel[1].motor = left;
            Wheel[0].motor = right;
            GameObject.FindGameObjectWithTag("Hero").transform.rotation = Quaternion.Euler(Vector3.left*180);
        }
        
    }
}
