using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Cat;
    private float distanceX;
    private float distanceY;
    private bool FangDajudge = false;
    private Camera Mcamera = null;

    // Start is called before the first frame update
    void Start()
    {
        distanceX = transform.position.x - Cat.position.x;
        distanceY = transform.position.y + Cat.position.y;
        Mcamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
           Cat.position.x + distanceX,
           transform.position.y,
           transform.position.z);
        if (!FangDajudge)
        {
            transform.position = new Vector3(
                transform.position.x, Cat.position.y,
                transform.position.z
                );
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Hero"))
        {
            FangDajudge = true;
            Mcamera.orthographicSize = 3;
        }
    }
}
