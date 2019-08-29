using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public float ForceY = 100.0f;
    public float ForceX = 10.0f;
    public float JumpHeight = 10.0f;

    private bool MousePressedJudge = false;
    private Rigidbody2D CatRig = null;
   // private Transform CarPos = null;
    private float CarY = 0;
    private float CatY = 0;
    private bool Grouded = false;
    private bool CanAddForce = false;
    // Start is called before the first frame update
    void Start()
    {
        CatRig = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ////Debug.Log(CatY);
        //if(Input.GetButtonUp("Fire1"))
            
        //Debug.Log("y");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Grouded = false;
        Debug.Log(" Grouded = false");
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Grouded = true;
        Debug.Log(" Grouded = true");
    }
    private void FixedUpdate()
    {
        CarY = GameObject.FindGameObjectWithTag("Car").transform.position.y;
        CatY = transform.position.y;
        MousePressedJudge = Input.GetButton("Fire1");
        if(Grouded)
        {
            CanAddForce = true;
        }
        else if (!Grouded)
        {
            if (Input.GetButtonUp("Fire1"))
                CanAddForce = false;
        }
        if(CatY - CarY >= JumpHeight)
        {
            CanAddForce = false;
        }

        if (MousePressedJudge&&CanAddForce)
        {
            CatRig.AddForce(new Vector2(ForceX, ForceY));
        }
    }
}
