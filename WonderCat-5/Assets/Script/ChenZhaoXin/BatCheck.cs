using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCheck : MonoBehaviour
{
    private Animator BatAnim = null;
    // Start is called before the first frame update
    void Start()
    {
        BatAnim =GameObject.FindGameObjectWithTag("bat").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BatAnim.SetTrigger("BatDead");
        GetComponent<EdgeCollider2D>().enabled = false;
        GameObject.FindGameObjectWithTag("bat").GetComponent<BoxCollider2D>().enabled = false;
    }
}
