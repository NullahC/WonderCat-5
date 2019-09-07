using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject MCamera = null;
    private Camera MCameraC = null;
    private float distanceX;
    private bool FangDajudge = false;
    private float ReduceingSize = 5;
    private float movingCamera;
    public bool PauseCamera=false;
    // Start is called before the first frame update
    void Start()
    {
        MCameraC = MCamera.GetComponent<Camera>();
        distanceX = MCamera.transform.position.x - transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        movingCamera = MCamera.transform.position.x ;
        if(!PauseCamera)
        {
            if (!FangDajudge)
            {
                MCamera.transform.position =
                new Vector3(
                transform.position.x + distanceX,
                transform.position.y,
                MCamera.transform.position.z);
            }
            else if (FangDajudge)
            {
                if (movingCamera - transform.position.x > -0.1 && movingCamera - transform.position.x < 0.1)
                    movingCamera = transform.position.x;
                else if (movingCamera > transform.position.x)
                    movingCamera = movingCamera - 0.05f;
                else if (movingCamera < transform.position.x)
                    movingCamera = movingCamera + 0.05f;

                MCamera.transform.position =
                new Vector3(
                movingCamera,
                MCamera.transform.position.y,
                MCamera.transform.position.z);
                if (ReduceingSize >= 3)
                    ReduceingSize = ReduceingSize - 0.05f;
                MCameraC.orthographicSize = ReduceingSize;
                //MCameraC.orthographicSize = Mathf.Lerp(5, 3, 0.5f);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("End"))
            FangDajudge = true;
        if (collision.gameObject.CompareTag("ZhaMen"))
            PauseCamera = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
            PauseCamera = true;
        if (collision.gameObject.CompareTag("DeathPlane"))
            PauseCamera = true;
    }
}
