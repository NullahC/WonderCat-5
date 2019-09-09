using System.Collections;
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
    private bool CarMove = true;
    private bool startFllow = false;
    private Transform CatT = null;
    private CircleCollider2D[] WheelsCollider = null;
    [HideInInspector]
    public bool Filped = false;
    private float distanceX = 0;
    // Start is called before the first frame update
    void Start()
    {
        WheelsCollider = GetComponentsInChildren<CircleCollider2D>();
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
        if( FollowTheCat&&startFllow)
        {
            transform.position =new Vector2(CatT.transform.position.x+distanceX, transform.position.y);
        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
          if (collision.gameObject.CompareTag("Hero"))
        {
            if (CarMove)
            {
                Wheel[0].useMotor = true;
                Wheel[1].useMotor = true;
                wheelmotorF.motorSpeed = MotorSpeed;
                wheelmotorB.motorSpeed = MotorSpeed;
                Wheel[0].motor = wheelmotorF;
                Wheel[1].motor = wheelmotorB;
                CarMove = false;

                distanceX = transform.position.x - CatT.position.x;
                startFllow = true;
                //CarRig.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            //CarRig.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (collision.gameObject.CompareTag("Reverser"))
            Filped = true;
        }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //CarRig.constraints = RigidbodyConstraints2D.None;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire")) ;
        else
        {
            CarRig.constraints = RigidbodyConstraints2D.None;
            GetComponent<EdgeCollider2D>().enabled = false;
            WheelsCollider[0].enabled = false;
            WheelsCollider[0].enabled = false;
        }
    }
}
