using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    private BoxCollider2D m_BOX;
    void Start()
    {
        m_BOX = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Car"))
        {
            m_BOX.isTrigger = true;
        }
    }
}
