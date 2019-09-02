using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Cat;
    private float distanceX;

    // Start is called before the first frame update
    void Start()
    {
        distanceX = transform.position.x - Cat.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
           Cat.position.x + distanceX,
           transform.position.y,
           transform.position.z);
    }
}
