using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bo : MonoBehaviour
{
    public GameObject Wave;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Vector3 mp = Input.mousePosition;
            Vector3 keyW = Camera.main.ScreenToWorldPoint(mp);
            Vector3 newW = new Vector3(keyW.x, keyW.y, 0);
            GameObject KW = Instantiate(Wave, newW, Quaternion.identity);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mp = Input.mousePosition;
            Vector3 keyW = Camera.main.ScreenToWorldPoint(mp);
            Vector3 newW = new Vector3(keyW.x, keyW.y, 0);
            GameObject KW = Instantiate(Wave, newW, Quaternion.identity);
        }
    }
}

