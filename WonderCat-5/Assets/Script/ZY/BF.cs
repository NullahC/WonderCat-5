using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BF : MonoBehaviour
{
    public AudioClip Bat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
           AudioSource.PlayClipAtPoint(Bat, Camera.main.transform.position);
        }
        
    }
}
