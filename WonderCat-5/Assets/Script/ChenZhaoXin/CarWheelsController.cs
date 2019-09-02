using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheelsController : MonoBehaviour
{
    private WheelJoint2D wheel = null;
    private bool a = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(a);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        a = true;
    }
}
