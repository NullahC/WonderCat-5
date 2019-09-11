using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public float ForceY = 100.0f;
    public float ForceX = 10.0f;
    public float JumpHeight = 10.0f;

    public AudioClip Jump = null;
    public AudioClip Land = null;
    public AudioClip DiamondDestory = null;
    public AudioClip BatDown = null;
    [HideInInspector]
    public static float Count = 0;

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
    private int InEndTimeCounter = 0;
    private bool Filped = false;
    private GameObject Car = null;
    private float BatDead = 0;
    private bool hitBat = false;
    private GameObject HitedBat = null;
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
        if (CatDead)
        {
            BoxC.enabled = false;
            CircleC.enabled = false;
            Anim.SetTrigger("Dead");
            CatRig.AddForce(new Vector2(-200, 400));
            CatDead = false;
        }
        else if (InEnd)
        {
            InEndTimeCounter++;
            if (InEndTimeCounter >= 130)
            {
                if (CatScaleXInEnd >= 0.05)
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
        if(hitBat)
        {  
            BatDead = BatDead - 0.1f;
            HitedBat.transform.position = 
                new Vector3(HitedBat.transform.position.x, BatDead, 0);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Grouded = false;
            AudioSource.PlayClipAtPoint(Jump, Camera.main.transform.position);
            Anim.SetBool("Grounded", false);
            Anim.SetBool("Falling", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Anim.SetBool("Grounded", true);
            AudioSource.PlayClipAtPoint(Land, Camera.main.transform.position);
            LastY = transform.position.y;
            Grouded = true;      
            Car = collision.gameObject;
            Filped = Car.GetComponent<CarController>().Filped;
            GetComponent<SpriteRenderer>().flipX = Filped;
        }
        if(collision.gameObject.CompareTag("BatCheck"))
        {
            AudioSource.PlayClipAtPoint(BatDown, Camera.main.transform.position);
            CatRig.AddForce(new Vector2(100, 200));
            BatDead = collision.gameObject.transform.position.y;
            HitedBat = collision.gameObject;
            hitBat = true;
        }

        if (collision.gameObject.CompareTag("ZhaMen")|| collision.gameObject.CompareTag("bat"))
            CatDead = true;
        if (collision.gameObject.CompareTag("End"))
        {
            InEnd = true;
            Anim.SetBool("Grounded", true);
        }

            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
            CatDead = true;

        if(collision.gameObject.CompareTag("diamond"))
        {
            Count++;
            AudioSource.PlayClipAtPoint(DiamondDestory, Camera.main.transform.position);
            Destroy(collision.gameObject);
        }
    }
    private void FixedUpdate()
    {
        CatY = transform.position.y;
        MousePressedJudge = Input.GetButton("Fire1");
        if(Grouded)
        {   Anim.SetBool("Grounded", true);
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
            if(!Filped)
            {
                CatRig.AddForce(new Vector2(ForceX, ForceY));
                Anim.SetBool("Jumping", true);         
            }
            else if(Filped)
            {
                CatRig.AddForce(new Vector2(-ForceX, ForceY));
                Anim.SetBool("Jumping", true);
            }
        }
    }
}
