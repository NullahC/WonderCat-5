﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float MotorSpeed = 400;
    public bool FollowTheCat = false;
    
    private WheelJoint2D []Wheel = null;
    private JointMotor2D wheelmotorF ;
    private JointMotor2D wheelmotorB;
    private Rigidbody2D CarRig = null;
    private bool CarMove = false;
    private Transform CatT = null;
    // Start is called before the first frame update
    void Start()
    {
        Wheel =GetComponentsInChildren<WheelJoint2D>();
        CarRig = GetComponent<Rigidbody2D>();
        CatT = GameObject.FindGameObjectWithTag("Hero").transform;
        wheelmotorF = Wheel[0].motor;
        wheelmotorB = Wheel[1].motor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if( FollowTheCat)
        {
            transform.position =new Vector2(CatT.transform.position.x-2, transform.position.y);
        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        Wheel[0].useMotor = true;
        Wheel[1].useMotor = true;
        wheelmotorF.motorSpeed = MotorSpeed;
        wheelmotorB.motorSpeed = MotorSpeed;
        Wheel[0].motor = wheelmotorF;
        Wheel[1].motor = wheelmotorB;

        CarRig.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        CarRig.constraints = RigidbodyConstraints2D.None;
    }
}
