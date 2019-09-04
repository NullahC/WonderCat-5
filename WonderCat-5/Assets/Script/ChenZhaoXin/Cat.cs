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
    private float LastY = 0;
    private float CatY = 0;
    private bool Grouded = false;
    private bool CanAddForce = false;
    private Animator Anim = null;
    private bool CatDead=false;
    private BoxCollider2D BoxC = null;
    private CircleCollider2D CircleC = null;
    private bool InEnd = false;
    private float CatScaleXInEnd = 0;
    private float CatPInend = 0;
    // Start is called before the first frame update
    void Start()
    {
        CatRig = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        BoxC = GetComponent<BoxCollider2D>();
        CircleC = GetComponent<CircleCollider2D>();
        CatScaleXInEnd = transform.localScale.x;
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
       // Debug.Log(" Grouded = false");
        Anim.SetBool("Grounded", false);            
        Anim.SetBool("Falling", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        LastY = transform.position.y;
        Grouded = true;
        Anim.SetBool("Grounded", true);
        if (collision.gameObject.CompareTag("ZhaMen")|| collision.gameObject.CompareTag("Fire"))
            CatDead = true;
        if (collision.gameObject.CompareTag("End"))
            InEnd = true;
        
    }
    private void FixedUpdate()
    {
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
            Anim.SetBool("Falling", true);
            Anim.SetBool("Jumping", false);
        }
        if(CatY - LastY >= JumpHeight)
        {
            CanAddForce = false;
            Anim.SetBool("Falling", true);
            Anim.SetBool("Jumping", false);
        }

        if (MousePressedJudge&&CanAddForce)
        {
            CatRig.AddForce(new Vector2(ForceX, ForceY));
            Anim.SetBool("Jumping", true);
        }

        if(CatDead)
        {
            BoxC.enabled = false;
            CircleC.enabled = false;
            Anim.SetTrigger("Dead");
            CatRig.AddForce(new Vector2(-200, 400));
            CatDead = false;
        }
        else if(InEnd)
        {
            if(CatScaleXInEnd>=0.05)
            CatScaleXInEnd = CatScaleXInEnd - 0.01f;
            transform.localScale = new Vector3(CatScaleXInEnd, transform.localScale.y, transform.localScale.z);
            if (CatScaleXInEnd <= 0.05)
            {
                CatPInend = CatPInend + 0.02f;
                transform.position = new Vector2(transform.position.x, transform.position.y + CatPInend);

                if (transform.position.y == 20)
                {
                    CatRig.gravityScale = 0;
                    InEnd = false;
                }
            }
        }
    }
}
